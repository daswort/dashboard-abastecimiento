global using DashboardAbast.Shared.Model.CerberusMinuta;
global using DashboardAbast.Shared.Model.Cerberus;
global using DashboardAbast.Shared.Model.PptoCe;
global using DashboardAbast.Shared.Model.AxCasino;
global using DashboardAbast.Shared.InterfaceDataModels;
global using DashboardAbast.Shared.StandarizedDbModel;
global using DashboardAbast.Shared.QueryModels;
global using DashboardAbast.Shared.Entidades.Modelos;
global using DashboardAbast.Shared.Entidades.Extensiones;
global using Microsoft.EntityFrameworkCore;
global using DashboardAbast.Server.Data;
global using DashboardAbast.Server.ContextFactory;
global using DashboardAbast.Server.Paging;
global using DashboardAbast.Server.Repositories;
global using DashboardAbast.Server.Repositories.OcNoRecepcionadasRepository;
global using DashboardAbast.Server.Repositories.CentroCostoRepository;
global using DashboardAbast.Server.Repositories.EjecutivoRepository;
global using DashboardAbast.Server.Repositories.ProveedorRepository;
global using DashboardAbast.Server.Repositories.ProductoRepository;
global using DashboardAbast.Server.Repositories.OcIConstruyeRepository;
global using DashboardAbast.Server.Repositories.RecepcionFolioRepository;
global using DashboardAbast.Server.Extensions;

using DashboardAbast.Server.Extensions.NoLockExtension;
using Microsoft.EntityFrameworkCore.Query;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

builder.Services.AddPooledDbContextFactory<PptoCeContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("PptoCeProdConnection"))
    .ReplaceService<IQuerySqlGeneratorFactory, WithNolockQuerySqlGeneratorFactory>()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .EnableThreadSafetyChecks(false);
}, poolSize: 32);

builder.Services.AddPooledDbContextFactory<CerberusMinutaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("CerberusMinutaProdConnection"))
    .ReplaceService<IQuerySqlGeneratorFactory, WithNolockQuerySqlGeneratorFactory>()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .EnableThreadSafetyChecks(false);
}, poolSize: 32);

builder.Services.AddPooledDbContextFactory<AxCasinoContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AxCasinoProdConnection"))
    .ReplaceService<IQuerySqlGeneratorFactory, WithNolockQuerySqlGeneratorFactory>()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .EnableThreadSafetyChecks(false);
}, poolSize: 32);

builder.Services.AddPooledDbContextFactory<CerberusContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("CerberusProdConnection"))
    .ReplaceService<IQuerySqlGeneratorFactory, WithNolockQuerySqlGeneratorFactory>()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .EnableThreadSafetyChecks(false);
}, poolSize: 32);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<PptoCeScopedFactory>();
builder.Services.AddScoped(sp => sp.GetRequiredService<PptoCeScopedFactory>().CreateDbContext());

builder.Services.AddScoped<AxCasinoScopedFactory>();
builder.Services.AddScoped(sp => sp.GetRequiredService<AxCasinoScopedFactory>().CreateDbContext());

builder.Services.AddScoped<CerberusScopedFactory>();
builder.Services.AddScoped(sp => sp.GetRequiredService<CerberusScopedFactory>().CreateDbContext());

builder.Services.AddScoped<CerberusMinutaScopedFactory>();
builder.Services.AddScoped(sp => sp.GetRequiredService<CerberusMinutaScopedFactory>().CreateDbContext());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
