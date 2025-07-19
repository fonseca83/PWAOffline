using Microsoft.AspNetCore.Mvc;
using ServidorWeb.Server.Views;
using ServidorWeb.Server.Views.Prueba4;
using ServidorWeb.Shared;

namespace ServidorWeb.Server.Controllers;

public class Prueba4Controller : Controller
{
    [HttpGet(RutasWeb.PaginasDeEjemplo.Prueba4)]
    public IActionResult Prueba4ModeloModificado()
    {
        var modelo = new MiModelo
        {
            Nombre = "Jane Doe",
            Edad = 34
        };
        // ViewBag.modelo = new MiModelo
        // {
        //     Nombre = "Jane Doe",
        //     Edad = 30
        // };
        return View(nameof(Views.Prueba4.Prueba4),modelo);
    }
    [HttpGet("/prueba4Default")]
    public IActionResult Prueba4()
    {
        return View(nameof(Views.Prueba4.Prueba4));
    }
}