using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);

            // Récupérer l'Id de l'employé pour l'envoi de l'Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await _emailSender.SendEmailAsync(user.Email, "Demande de congés annulée", $"Votre demande de congés du " +
               $"{leaveRequest.StartDate} au {leaveRequest.EndDate} a été annulée avec succès.");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                // Récupérer le nombre de jours alloués pour ce type de congés pour cet employé
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                // on calcule le nombre de jours de congés demandés
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                // on met à jour le nombre de jours de congés disponibles, en fonction du nombre de jours approuvés
                allocation.NumberOfDays -= daysRequested;
                await _leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            // Récupérer l'Id de l'employé pour l'envoi de l'Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // On défini le texte à afficher en fonction de l'état d'approbation pour le titre de l'Email
            var approvalStatus = approved ? "Approuvée" : "Rejetée";

            await _emailSender.SendEmailAsync(user.Email, $"Demande de congés {approvalStatus}", $"Votre demande de congés du " +
               $"{leaveRequest.StartDate} au {leaveRequest.EndDate} a été {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // Récupérer les infos de l'utilisateur pour lui attribuer les congés posés
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            // Vérifier que le nombre de jours déposés n'excède pas le nombre de jours alloués restants
            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null)
            {
                return false;
            }

            int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // Régler les propriétés qui n'ont pas été renseignées par l'utilisateur
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Demande de congés soumise avec succès.", $"Votre demande de congés du " +
                $"{leaveRequest.StartDate} au {leaveRequest.EndDate} a été soumise pour approbation.");

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

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(e => e.RequestingEmployeeId == employeeId)
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
