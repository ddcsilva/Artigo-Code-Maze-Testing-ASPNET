using FuncionariosApp.Contracts;
using FuncionariosApp.Extensions;
using FuncionariosApp.Models;
using FuncionariosApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FuncionarioContext>(opts =>
			   opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Funcionarios}/{action=Index}/{id?}");

app.MigrateDatabase();
app.Run();
