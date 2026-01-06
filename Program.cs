using BibliotecaDigital.Core.Entities;
using BibliotecaDigital.Data.Contexts.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();


//// Configurar el contexto de la base de datos
//builder.Services.AddDbContext<BibliotecaContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



//añadir servicios
//DefaultConnection es la clave valor en appsettings.json
//INI: EF Core
//////////////////////////////////////////////////////////////////////////////?? significa entonces, si la parte izquierda es null coge la derecha
string cnnString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
//para entity framework 
//inyeccion por dependencia del dbcontext
builder.Services.AddDbContext<BibliotecaContext>(opt =>
opt.UseSqlServer(cnnString));
//FINI: EF Core



//INI: NUESTRA CONFIGURACION PARA SIMULAR UNA AUTENTICACION 
builder.Services.AddAuthentication("MiCookieAuth")
    .AddCookie("MiCookieAuth", opt =>
    {
        //controlado que gestiona la cookie
        //le indico nuestra forma de logear
        opt.LoginPath = "/Cuenta/LoginSimulado";
    });
builder.Services.AddAuthorization();
//FIN: NUESTRA CONFIGURACION PARA SIMULAR UNA AUTENTICACION




var app = builder.Build();


//builder.Services.AddDbContext<BibliotecaContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllersWithViews();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
