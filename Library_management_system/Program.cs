using Library_management_system.Application.Commands;
using Library_management_system.Application.Mappers;
using Library_management_system.Application.Querys;
using Library_management_system.DOMAIN.Interfaces;
using Library_management_system.Infrastructure.Data;
using Library_management_system.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("localCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
