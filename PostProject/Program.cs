using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PostProject.Application.Features.Clients.Queries;
using PostProject.Application.Features.MappingProfiles;
using PostProject.Application.Features.Security.Password;
using PostProject.DataAcces.Data;
using PostProject.DataAcces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientsQuery).Assembly));

builder.Services.AddAutoMapper(typeof(ClientProfile));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
