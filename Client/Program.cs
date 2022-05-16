global using DashboardAbast.Client.Services.OrdenCompraService;
global using DashboardAbast.Client.Services.CentroCostoService;
global using DashboardAbast.Client.Services.DespachosDiaService;
global using DashboardAbast.Client.Services.DespachosAtrasadosService;
global using DashboardAbast.Client.Services.ProveedorService;
global using DashboardAbast.Client.Services.FamiliaService;
global using DashboardAbast.Client.Services.EjecutivoService;
global using DashboardAbast.Client.Services.ResumenEntidadService;
global using DashboardAbast.Client.Services.GerenciaService;
global using DashboardAbast.Client.Services.JefaturaService;
global using DashboardAbast.Client.Services;
global using DashboardAbast.Shared.Model.CerberusMinuta;
global using DashboardAbast.Shared.Model.PptoCe;
global using DashboardAbast.Shared.Model.AxCasino;
global using DashboardAbast.Shared.ChartDataModels;
global using DashboardAbast.Shared.InterfaceDataModels;
global using DashboardAbast.Shared.StandarizedDbModel;
global using DashboardAbast.Shared.Entidades.Modelos;
global using DashboardAbast.Client.Misc;

using DashboardAbast.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<ICentroCostoService, CentroCostoService>();
builder.Services.AddScoped<IFamiliaService, FamiliaService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IDespachosDiaService, DespachosDiaService>();
builder.Services.AddScoped<IDespachosAtrasadosService, DespachosAtrasadosService>();
builder.Services.AddScoped<IEjecutivoService, EjecutivoService>();
builder.Services.AddScoped<IResumenEntidadService, ResumenEntidadService>();
builder.Services.AddScoped<IGerenciaService, GerenciaService>();
builder.Services.AddScoped<IJefaturaService, JefaturaService>();
builder.Services.AddScoped<ExportService>();

await builder.Build().RunAsync();
