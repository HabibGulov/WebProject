public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<bool> AddEmployeeAsync(Employee employee);
    Task<bool> UpdateEmployeeAsync(Employee employee);
    Task<bool> DeleteEmployeeAsync(Guid id);
    Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(bool isActive);
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(Guid departmentId);
    Task<SalaryStatistics?> GetSalaryStatisticsAsync();
    Task<IEnumerable<Employee>> GetEmployeesByBirthdaysAsync(DateTime startDate, DateTime endDate);
}