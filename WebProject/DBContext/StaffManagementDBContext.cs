using Microsoft.EntityFrameworkCore;

public class StaffManagementDBContext : DbContext
{
    public StaffManagementDBContext(DbContextOptions<StaffManagementDBContext> options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfigurations).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}