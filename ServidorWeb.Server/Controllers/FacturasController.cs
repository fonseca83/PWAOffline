using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorWeb.Client.ModelsLocal;
using ServidorWeb.Server.Models;
using ServidorWeb.Shared;
using System.Net.NetworkInformation;


namespace ServidorWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly MiAppDbContext _context;

        public FacturasController(MiAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Factura>> Get() => await _context.Facturas.ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return Ok(factura);
        }

        [HttpPost("api/facturas/sync")]
        public async Task<IActionResult> SyncFacturas([FromBody] List<FacturaLocal> facturas)
        {
            var facturasDb = facturas.Select(f => new ServidorWeb.Server.Models.Factura
            {
                Cliente = f.Cliente,
                Fecha = f.Fecha??DateTime.Today,
                Total = f.Total
            }).ToList();

            _context.Facturas.AddRange(facturasDb);
            await _context.SaveChangesAsync();

            return Ok();
        }





    }

}
