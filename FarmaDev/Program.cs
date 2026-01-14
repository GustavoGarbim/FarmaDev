using FarmaDev.Application.Interfaces;
using FarmaDev.Application.Services;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.Data;
using FarmaDev.Infraestructure.ExternalServices;
using FarmaDev.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var mailgunSettings = builder.Configuration.GetSection("MailgunSettings");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddFluentEmail("contato@suafarmacia.com")
    .AddMailGunSender(
        mailgunSettings["Domain"],
        mailgunSettings["ApiKey"]
    );

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddDbContext<FarmaDevDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
