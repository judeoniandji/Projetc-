using GestionDesCommandes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur.
builder.Services.AddControllersWithViews();

// Configuration de la base de donn�es avec Entity Framework Core et PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajouter la gestion des sessions et l'authentification par cookies
builder.Services.AddDistributedMemoryCache(); // Pour stocker les sessions
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Ajouter la configuration pour l'authentification par cookies
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirection si non authentifi�
        options.LogoutPath = "/Account/Logout";
    });

// Ajouter d'autres services si n�cessaire (par exemple, les services de logique m�tier)

// Construire l'application
var app = builder.Build();

// Configurer le pipeline de requ�tes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Utiliser les sessions et l'authentification
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Utilisation des fichiers statiques (si n�cessaire pour le front-end)
app.UseStaticFiles();

// Routage des contr�leurs et vues
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Lancer l'application
app.Run();
