using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ServidorWeb.Client;
using ServidorWeb.Client.ModelsLocal;
using ServidorWeb.Client.Services;
using Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// HttpClient
builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});


//Servicio TItulo
builder.Services.AddScoped<TitleService>();


//Servicio para Sincronizar la base de datos
builder.Services.AddScoped<SyncService>();



// MudBlazor
builder.Services.AddMudServices();

// Bases de datos
builder.Services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();
builder.Services.AddScoped<FacturasDb>();
builder.Services.AddScoped<FacturaService>();

//builder.Services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();

//builder.Services.AddSingleton(_ =>
//    IndexedDbOptionsFactory.Create(
//        databaseName: "MiAppOfflineDB",
//        version: 1,
//        storeNames: new[] { nameof(FacturasDb.Facturas) }
//    )
//);


await builder.Build().RunAsync();