using Microsoft.AspNetCore.Mvc;

[Route("/api/employee/")]
[ApiController]

public class PersonController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployees(IEmployeeRepository employeeRepository)
    {
        IEnumerable<Employee> employees = await employeeRepository.GetAllEmployeesAsync();
        if (employees == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(employees);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateEmployee(IEmployeeRepository employeeRepository, [FromBody] Employee? employee)
    {
        if (employee == null)
        {
            return Results.BadRequest("Employee is null");
        }
        bool response = await employeeRepository.AddEmployeeAsync(employee);
        if (response == false)
        {
            return Results.BadRequest("Employee not created");
        }
        return Results.Ok("Employee added");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> DeleteEmployee(IEmployeeRepository employeeRepository, [FromRoute] Guid? id)
    {
        if (id == null)
        {
            return Results.BadRequest("Id is null.");
        }
        bool response = await employeeRepository.DeleteEmployeeAsync((Guid)id);
        if (response == false)
        {
            return Results.BadRequest("Employee was not deleted.");
        }
        return Results.Ok("Employee deleted!");
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployeeById(IEmployeeRepository employeeRepository, [FromRoute] Guid? id)
    {
        if (id == null)
        {
            return Results.BadRequest("Id is null.");
        }
        Employee? employee = await employeeRepository.GetEmployeeByIdAsync((Guid)id);
        if (employee == null)
        {
            return Results.NotFound("Employee was not found");
        }
        return Results.Ok(employee);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> UpdateEmployee(IEmployeeRepository employeeRepository, [FromBody] Employee? employee)
    {
        if (employee == null)
        {
            return Results.BadRequest("Employee object is null");
        }
        bool response = await employeeRepository.UpdateEmployeeAsync(employee);
        if (response == false)
        {
            return Results.BadRequest("Employee was not updated");
        }
        return Results.Ok("Employee Updated");
    }

    [HttpGet("status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployeesByStatus(IEmployeeRepository employeeRepository, [FromQuery] bool isActive)
    {
        IEnumerable<Employee> employees = await employeeRepository.GetEmployeesByStatusAsync(isActive);
        if (employees == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(employees);
    }

    [HttpGet("department/{departmentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployeesByDepartmentId(IEmployeeRepository employeeRepository, [FromRoute] Guid departmentId)
    {
        IEnumerable<Employee> employees = await employeeRepository.GetEmployeesByDepartmentIdAsync(departmentId);
        if (employees == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(employees);
    }

    [HttpGet("salary-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> GetSalaryStatistics(IEmployeeRepository employeeRepository)
    {
        SalaryStatistics? salaryStatistics = await employeeRepository.GetSalaryStatisticsAsync();
        if (salaryStatistics == null)
        {
            return Results.BadRequest("Statistics are null");
        }
        return Results.Ok(salaryStatistics);
    }

    [HttpGet("birthdays")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployeesByBirthdays(IEmployeeRepository employeeRepository, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        IEnumerable<Employee> employees = await employeeRepository.GetEmployeesByBirthdaysAsync(startDate, endDate);
        if (employees == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(employees);
    }
}