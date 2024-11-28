using DataAccess.Configuracion;
using DataAccess.Repositorio;
using EmpleadosWebSiteExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ConnectionConfiguration>(
    builder.Configuration.GetSection("ConnectionConfiguration"));
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
//builder.Services.AddScoped<HomeController>();

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
