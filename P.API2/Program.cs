using Microsoft.EntityFrameworkCore;
using P.Repository;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using P.Interfaces;
using System.Text;
using P.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


// Servicios
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllersWithViews().
         AddJsonOptions(options =>
         {
             options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
             options.JsonSerializerOptions.PropertyNamingPolicy = null;
         });

// Repositorios
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//create database MVCVERDADERO

//CREATE TABLE USUARIOS(
//ID INT PRIMARY KEY IDENTITY,
//USERNAME VARCHAR(100),
//PASSWORD VARCHAR(100),
//NAME VARCHAR(100),
//GUID VARCHAR(100)

//);
