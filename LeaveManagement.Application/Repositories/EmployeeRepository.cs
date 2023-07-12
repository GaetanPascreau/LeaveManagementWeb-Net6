using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LeaveManagement.Application.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Users.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployeesBySupervisorId(string supervisorId)
        {
            if (supervisorId == null)
            {
                return null;
            }

            return await _context.Users.Where(user => user.SupervisorId == supervisorId).ToListAsync();
        }        
    }
}
