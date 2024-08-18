using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.Models;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PROYECTO_FLK.BACKEND.Servicios.Contrato;
using PROYECTO_FLK.BACKEND.Servicios.Implementacion;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BdSswoggflkContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));

});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {

        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });


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

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                name: "AsistententeOperaciones",
                pattern: "AsistenteOperaciones",
                defaults: new { controller = "AsistenteOperaciones", action = "AsistentedeOperaciones" });
    endpoints.MapControllerRoute(
            name: "Recepcionista",
            pattern: "Recepcionista",
            defaults: new { controller = "Recepcionista", action = "Recepcionista" });
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin",
        defaults: new { controller = "Admin", action = "Administrador" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");
        endpoints.MapControllerRoute(
            name: "Empresas",
            pattern: "{controller=Empresas}/{action=GestionarEmpresas}/{id?}");
    });




app.Run();
