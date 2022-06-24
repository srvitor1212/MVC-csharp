﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cerveja.Data;
using Cerveja.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CervejaContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("CervejaContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//options.UseSqlServer(builder.Configuration.GetConnectionString("CervejaContext") ?? throw new InvalidOperationException("Connection string 'CervejaContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<DadosFake>();        //todo: Não tenho certeza se é o correto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
