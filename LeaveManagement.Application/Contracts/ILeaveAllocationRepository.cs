using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string EmployeeId, int LeaveTypeId, int period);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationVM model);
    }
}
