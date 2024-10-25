using AutoMapper;
using Library_management_system.Application.Commands;
using Library_management_system.Application.Events.Interfaces;
using Library_management_system.Application.Mappers;
using Library_management_system.Application.Querys;
using Library_management_system.DOMAIN.Entities;
using Library_management_system.DOMAIN.Interfaces;
using Library_management_system.Infrastructure.Data;
using Library_management_system.Infrastructure.Repositories;
using Library_management_system.Infrastructure.Security;
using Library_management_system.Infrastructure.Services;
using Library_management_system.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<GetAllPrestamoQuery>();
    cfg.RegisterServicesFromAssemblyContaining<AddPrestamoCommand>();

});

builder.Services.AddAutoMapper(typeof(ConfigurationMapper).Assembly);
// INI Configuración de JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    };
});
builder.Services.AddScoped<JwtTokenGenerator>(); // Registro del generador de tokens
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
//FIN Configuración de JWT

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<SmtpClient>(sp =>
{
    var emailSettings = sp.GetRequiredService<IOptions<EmailSettings>>().Value;
    var smtpClient = new SmtpClient(emailSettings.SmtpServer, emailSettings.SmtpPort)
    {
        Credentials = new NetworkCredential(emailSettings.FromEmail, emailSettings.Password),
        EnableSsl = true
    };
    return smtpClient;
});
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddTransient<IPrestamoRepository, PrestamoRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("localCors",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRequestTiming(); //Middleware para medir tiempo de respuesta
app.JwtMiddleware(); //Middleware para validar token
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("localCors");
app.UseHttpsRedirection();

app.UseAuthentication(); //Habilitar Middleware para auth
app.UseAuthorization();

app.MapControllers();

app.Run();
