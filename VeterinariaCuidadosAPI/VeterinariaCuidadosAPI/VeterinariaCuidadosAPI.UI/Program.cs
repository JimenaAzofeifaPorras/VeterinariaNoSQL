using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using VeterinariaCuidadosAPI.UI.Data;
using VeterinariaCuidadosAPI.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IClienteService, ClienteService>(
    client => { client.BaseAddress = new Uri("https://localhost:44385/"); });


builder.Services.AddHttpClient<ICitaService, CitaService>(
    client => client.BaseAddress = new Uri("http://localhost:5139/"));

builder.Services.AddHttpClient<IClienteService, ClienteService>(
    client => client.BaseAddress = new Uri("http://localhost:5139/"));

builder.Services.AddHttpClient<IRecetaService, RecetaService>(
    client => client.BaseAddress = new Uri("http://localhost:5139/"));

builder.Services.AddHttpClient<IRetroalimentacionService, RetroalimentacionService>(
    client => client.BaseAddress = new Uri("http://localhost:5139/"));

builder.Services.AddHttpClient<IMascotaService, MascotaService>(
    client => client.BaseAddress = new Uri("http://localhost:5139/"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
