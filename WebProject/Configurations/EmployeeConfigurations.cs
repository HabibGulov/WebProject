using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfigurations:IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("Id").HasColumnType("uuid");
        builder.Property(x => x.FirstName).IsRequired().HasColumnName("FirstName").HasColumnType("varchar(100)");
        builder.Property(x => x.LastName).IsRequired().HasColumnName("LastName").HasColumnType("varchar(100)");
        builder.HasAlternateKey(x => x.Email);
        builder.Property(x => x.Email).IsRequired().HasColumnName("Email").HasColumnType("varchar(255)");
        builder.Property(x => x.Phone).IsRequired().HasColumnName("Phone").HasColumnType("varchar(20)"); 
        builder.Property(x => x.DateOfBirth).IsRequired().HasColumnName("DateOfBirth").HasColumnType("date");
        builder.Property(x => x.HireDate).IsRequired().HasColumnName("HireDate").HasColumnType("date");
        builder.Property(x => x.Position).IsRequired().HasColumnName("Position").HasColumnType("varchar(100)");
        builder.Property(x => x.Salary).IsRequired().HasColumnName("Salary").HasColumnType("decimal(18, 2)");
        builder.Property(x => x.DepartmentId).IsRequired().HasColumnName("DepartmentId").HasColumnType("uuid");
        builder.Property(x => x.ManagerId).IsRequired().HasColumnName("ManagerId").HasColumnType("uuid");
        builder.Property(x => x.IsActive).IsRequired().HasColumnName("IsActive").HasColumnType("boolean").HasDefaultValue(true);
        builder.Property(x => x.Address).IsRequired().HasColumnName("Address").HasColumnType("varchar(255)");
        builder.Property(x => x.City).IsRequired().HasColumnName("City").HasColumnType("varchar(100)");
        builder.Property(x => x.Country).IsRequired().HasColumnName("Country").HasColumnType("varchar(100)");
        builder.Property(x => x.CreatedAt).IsRequired().HasColumnName("CreatedAt").HasColumnType("date").HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.UpdatedAt).IsRequired().HasColumnName("UpdatedAt").HasColumnType("date").HasDefaultValueSql("current_timestamp");
    }
}