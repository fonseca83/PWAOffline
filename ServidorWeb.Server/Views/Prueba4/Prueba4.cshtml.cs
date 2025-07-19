using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServidorWeb.Server.Views.Prueba4;

public class Prueba4 : PageModel
{
    public MiModelo Modelo { get; set; } = null!;

    public IActionResult OnGet()
    {
        // Lógica para inicializar el modelo de la vista
        Modelo = new MiModelo
        {
            Nombre = "xxxx",
            Edad = 11
        };
        return Page();
    }
}
public class MiModelo
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}