using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StaffManagementDBContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddCustomServices();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseMiddleware<AgeCheckMiddleware>();
app.MapControllers();
app.Run();