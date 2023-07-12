using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context,
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string EmployeeId, int LeaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == EmployeeId
                                                                && q.LeaveTypeId == LeaveTypeId
                                                                && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            // Récupérer la liste des allocations par type de congés (et avec ses détails) pour l'employé précisé
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync();

            // Récupérer les informations de l'employé
            var employee = await _userManager.FindByIdAsync(employeeId);

            // Combiner ces informations pour les afficher dans le modèle
            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            // Récupérer une allocation par type de congés (et avec ses détails) via son Id
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            // Récupérer les informations de l'employé
            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            // Combiner ces informations pour les afficher dans le modèle
            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = _mapper.Map<EmployeeListVM>(employee);

            return model;
        }


        public async Task LeaveAllocation(int leaveTypeId)
        {
            // Obtenir la liste de tous les employés
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);

            // Obtenir la période
            var period = DateTime.Now.Year;

            // Obtenir le type de congés
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

            // Créer une liste d'allocations et une liste d'employés
            var allocations = new List<LeaveAllocation>();
            var employeeWithNewAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue; // si l'allocation existe pour cet employé, on passe au suivant

                // Créer une nouvele allocation
                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });

                employeeWithNewAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            // on envoie un email seulement aux employés qui ont reçu la nouvelle allocation
            foreach(var employee in employeeWithNewAllocations)
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Allocation des congés pour {period}",
                    $"Vos {leaveType.Name} " + 
                    $"ont été postés pour la période de {period}. {leaveType.DefaultDays} jours vous ont été attribués.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;

            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
