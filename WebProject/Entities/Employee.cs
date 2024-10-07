public class Employee : Person
{
    public DateTime HireDate { get; set; }
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? ManagerId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}