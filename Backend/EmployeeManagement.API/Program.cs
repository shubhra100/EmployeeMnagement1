using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/////////////////////////////////////////////////////
// DATABASE
/////////////////////////////////////////////////////

builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

/////////////////////////////////////////////////////
// CORS
/////////////////////////////////////////////////////

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

/////////////////////////////////////////////////////
// SERVICES
/////////////////////////////////////////////////////

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/////////////////////////////////////////////////////
// BUILD
/////////////////////////////////////////////////////

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();