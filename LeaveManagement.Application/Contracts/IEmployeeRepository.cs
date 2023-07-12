using LeaveManagement.Data;

namespace LeaveManagement.Application.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<List<Employee>> GetEmployeesBySupervisorId(string supervisorId);
    }
}
