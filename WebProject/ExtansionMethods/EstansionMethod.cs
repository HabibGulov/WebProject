public static class ExtansionMethod
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    }
}