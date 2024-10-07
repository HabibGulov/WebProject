
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;

public class EmployeeRepository(StaffManagementDBContext staffManagementDBContext) : IEmployeeRepository
{
    public async Task<bool> AddEmployeeAsync(Employee employee)
    {
        try
        {
            staffManagementDBContext.Employees.Add(employee);
            int res = await staffManagementDBContext.SaveChangesAsync();
            return res != 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        try
        {
            Employee? employee = await staffManagementDBContext.Employees.FindAsync(id);
            if (employee == null) return false;
            staffManagementDBContext.Employees.Remove(employee);
            int res = await staffManagementDBContext.SaveChangesAsync();
            return res > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            return await staffManagementDBContext.Employees.FindAsync(id);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new Employee();
        }
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            return await staffManagementDBContext.Employees.ToListAsync();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Employee>();
        }
    }
    public async Task<bool> UpdateEmployeeAsync(Employee employee)
    {
        try
        {
            Employee? employee1 = await staffManagementDBContext.Employees.FindAsync(employee.Id);
            if (employee1 == null)
            {
                return false;
            }
            employee1.Id = employee.Id;
            employee1.FirstName = employee.FirstName;
            employee1.LastName = employee.LastName;
            employee1.Email = employee.Email;
            employee1.Phone = employee.Phone;
            employee1.DateOfBirth = employee.DateOfBirth;
            employee1.HireDate = employee.HireDate;
            employee1.Position = employee.Position;
            employee1.Salary = employee.Salary;
            employee1.DepartmentId = employee.DepartmentId;
            employee1.ManagerId = employee.ManagerId;
            employee1.IsActive = employee.IsActive;
            employee1.Address = employee.Address;
            employee1.City = employee.City;
            employee1.Country = employee.Country;
            employee1.CreatedAt = employee.CreatedAt;
            employee1.UpdatedAt = employee.UpdatedAt;

            int res = await staffManagementDBContext.SaveChangesAsync();
            return res > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(bool isActive)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.getEmployeesByStatus, new { IsActive = isActive });
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Employee>();
        }
    }
    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(Guid departmentId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.getEmployeesByDepartmentId, new { DepartmentId = departmentId });
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Employee>();
        }
    }

    public async Task<SalaryStatistics?> GetSalaryStatisticsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<SalaryStatistics>(SqlCommands.getSalaryStatistics);
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new SalaryStatistics();
        }
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByBirthdaysAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.getEmployeesByBirthdays, new {startDate, endDate});
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Employee>();
        }
    }
}

file class SqlCommands
{
    public static string connectionString = "Server=localhost;Port=5432;Database=employee_management_db;Username=postgres;Password=12345;";
    public static string getEmployeesByStatus = @"SELECT *
                                                FROM ""Employees""
                                                WHERE ""IsActive"" = @isActive;";
    public static string getEmployeesByDepartmentId = @"SELECT *
                                                FROM ""Employees""
                                                WHERE ""DepartmentId"" = @departmentId;";
    public static string getSalaryStatistics = @"SELECT 
                                                AVG(""Salary"") AS AverageSalary, 
                                                MIN(""Salary"") AS MinimumSalary, 
                                                MAX(""Salary"") AS MaximumSalary, 
                                                COUNT(*) AS EmployeeCount 
                                                FROM ""Employees""";
    public static string getEmployeesByBirthdays = @"SELECT * FROM ""Employees"" WHERE  ""DateOfBirth"" > @startDate AND ""DateOfBirth"" `< @endDate";
}