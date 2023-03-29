global using employeeProject.Services.EmailService;
global using employeeProject.Models;

using employeeProject.data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

}));


//Email
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddDbContext<MainDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("corsapp");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
