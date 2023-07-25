using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        // Définir les jours fériés de l'année en cours
        List<DateTime> holidays = new List<DateTime>
        {
            new DateTime(2023,01,01),   // jour de l'an
            new DateTime(2023,04,10),   // lundi de Pâques
            new DateTime(2023,05,01),   // Fête du travail
            new DateTime(2023,05,08),   // Armistice 1945
            new DateTime(2023,05,18),   // jeudi de l'Ascension
            new DateTime(2023,05,29),   // lundi de Pentcôte
            new DateTime(2023,07,14),   // Fête nationale
            new DateTime(2023,08,15),   // Assomption
            new DateTime(2023,11,01),   // Toussaint
            new DateTime(2023,11,11),   // Armistice 1918
            new DateTime(2023,12,25)    // Noël
        };

        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender,
            ILeaveTypeRepository leaveTypeRepository,
            IEmployeeRepository employeeRepository) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
            _leaveTypeRepository = leaveTypeRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);

            // Récupérer l'Id de l'employé pour l'envoi de l'Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // Régler les propriétés qui n'ont pas été renseignées par l'utilisateur
            leaveRequest.LeaveType = _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId).Result;

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} annulée",
               $"Votre demande de {leaveRequest.LeaveType.Name} du " +
               $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
               $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
               $" a été annulée avec succès.");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;
            double leaveDays = 0;

            if (approved)
            {
                // Récupérer le nombre de jours alloués pour ce type de congés pour cet employé
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

                // Récupérer le nombre de jours entiers sans les week-ends et jours fériés
                for (DateTime date = (DateTime)leaveRequest.StartDate; date <= leaveRequest.EndDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(date))
                    {
                        leaveDays++;
                    }
                }

                // prise en compte des demi-journées
                if (leaveRequest.StartTime == "après-midi" && leaveRequest.EndTime == "après-midi")
                {
                    leaveDays -= 0.5;
                }
                else if (leaveRequest.StartTime == "matin" && leaveRequest.EndTime == "matin")
                {
                    leaveDays -= 0.5;
                }
                else if (leaveRequest.StartTime == "après-midi" && leaveRequest.EndTime == "matin")
                {
                    leaveDays -= 1;
                }

                // on met à jour le nombre de jours de congés disponibles, en fonction du nombre de jours approuvés
                allocation.NumberOfDays -= leaveDays;
                await _leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            // Récupérer l'Id de l'employé pour l'envoi de l'Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // Régler les propriétés qui n'ont pas été renseignées par l'utilisateur
            leaveRequest.LeaveType = _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId).Result;

            // On défini le texte à afficher en fonction de l'état d'approbation pour le titre de l'Email
            var approvalStatus = approved ? "Approuvée" : "Rejetée";

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} {approvalStatus}",
               $"Votre demande de {leaveRequest.LeaveType.Name} du " +
               $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
               $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
               $" ({leaveDays} jours)" +
               $" a été {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // Récupérer les infos de l'utilisateur pour lui attribuer les congés posés
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            // Récupérer le nombre de jours alloués restants pour l'employé concerné
            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null)
            {
                return false;
            }

            // Récupérer le nombre de jours entiers sans les week-ends et jours fériés
            double leaveDays = 0;
            for (DateTime date = (DateTime)model.StartDate; date <= model.EndDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(date))
                {
                    leaveDays++;
                }
            }

            // prise en compte des demi-journées
            if (model.StartTime == "après-midi" && model.EndTime == "après-midi")
            {
                leaveDays -= 0.5;
            }
            else if (model.StartTime == "matin" && model.EndTime == "matin")
            {
                leaveDays -= 0.5;
            }
            else if (model.StartTime == "après-midi" && model.EndTime == "matin")
            {
                leaveDays -= 1;
            }

            // Vérifier que le nombre de jours déposés n'excède pas le nombre de jours alloués restants
            if (leaveDays > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // Régler les propriétés qui n'ont pas été renseignées par l'utilisateur
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;
            leaveRequest.LeaveType = _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId).Result;
            leaveRequest.RequestedDaysNumber = leaveDays;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise avec succès.",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " + 
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" ({leaveDays} jours)" +
                $" a été soumise pour approbation.");

            var supervisorId = user.SupervisorId;
            var supervisor = _employeeRepository.GetEmployeeByIdAsync(supervisorId);

            await _emailSender.SendEmailAsync(supervisor.Result.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise pour approbation.",
                $"Une demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" ({leaveDays} jours)" +
                $" a été soumise par {user.FirstName} {user.LastName} pour approbation.");

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            // Récupérer toutes les demandes de congés, en incluant le type de congés
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(l => l.Approved == true),
                RejectedRequests = leaveRequests.Count(l => l.Approved == false),
                PendingRequests = leaveRequests.Count(l => l.Approved == null),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            // Récupérer les infos de l'utilisateur qui a fait la demande de congés
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<AdminLeaveRequestViewVM> GetLeaveRequestsBySupervisorIdAsync(string supervisorId)
        {
            // 1) récupérer les Employés associés au superviseur
            var employees = await _employeeRepository.GetEmployeesBySupervisorId(supervisorId);

            // 2) Récupérer les demandes de congés de ces employés (associés au superviseur)
            var leaveRequests = new List<LeaveRequestVM>();
            var employeeRequests = new List<LeaveRequestVM>();

            foreach(var employee in employees)
            {
                employeeRequests = await this.GetAllAsync(employee.Id);
                leaveRequests.AddRange(employeeRequests);
            }

            // 3) Ajouter les statistiques au tableau de bord
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(l => l.Approved == true),
                RejectedRequests = leaveRequests.Count(l => l.Approved == false),
                PendingRequests = leaveRequests.Count(l => l.Approved == null),
                LeaveRequests = leaveRequests
            };

            // 4) Récupérer les infos de l'utilisateur qui a fait la demande de congés
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }


        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Where(e => e.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
            {
                return null;
            }

            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            
            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            // Récupérer l'employé qui a fait la demande
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            // Récupérer ses allocations (mais sans les infos supplémentaires = infos sur l'employé...)
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            // Récupérer la listes de ses demandes de congés et la convertir
            var requests = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;
        }
    }
}
