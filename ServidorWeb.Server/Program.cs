using Microsoft.AspNetCore.Components;
using ServidorWeb.Server.Components;
using ServidorWeb.Server.Funciones;

#region Agregamos Los servicios de Blazor Server y Blazor WebAssembly

GestionarServiciosYWebApplication.Add((services) =>
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
        // Indicamos que el servidor web debe usar el archivo de configuración appsettings.json
        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!) });
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri ) });


    }, (app) =>
    {
        
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            //.AddAdditionalAssemblies(typeof(Counter).Assembly)
            .AddAdditionalAssemblies(typeof(ServidorWeb.Client.App).Assembly)  
            ;
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
    }
);
#endregion

#region Agregamos los Controllers
GestionarServiciosYWebApplication.Add(servicios =>
{
    servicios.AddControllersWithViews();
#if !SinSoporteMVC
    Console.WriteLine("Agregando MVC");
    servicios.AddMvc();
    // servicios.AddMvcCore().AddMvcOptions(options =>
    // {
    //     options.EnableEndpointRouting = false;
    // });
#endif
#if !SinSoporteCshtml
    Console.WriteLine("Agregando RazorPages");
    servicios.AddRazorPages().AddRazorPagesOptions(options =>
    {
        options.RootDirectory = "/Components/ServerPages";
    } );
#endif
    //servicios.AddRazorPages();
}, app =>
{
    app.UseRouting();
    app.UseAntiforgery();
#if !SinSoporteMVC    
    app.MapControllers();
#endif
#if !SinSoporteCshtml
    app.MapRazorPages();
#endif
    // app.UseEndpoints(endpoints =>
    // {
    //     endpoints.MapControllers();
    //     //endpoints.MapRazorPages();
    // });
});
#endregion
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorComponents()
//     .AddInteractiveServerComponents();
builder.Services.AgregarServiciosCustomizados();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseAntiforgery();

// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();
app.AgregarUsosCustomizados();
app.Run();