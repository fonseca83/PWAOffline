using Blazor.IndexedDB;
using ServidorWeb.Client.ModelsLocal;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace ServidorWeb.Client.Services
{


    public class FacturaService
    {
        
        private readonly IIndexedDbFactory _dbFactory;
        private  FacturasDb _db;
        private bool _initialized = false;


        public FacturaService(FacturasDb db, IIndexedDbFactory dbFactory)
        {
            _db = db;
            _dbFactory = dbFactory;
        }



        public async Task EnsureInitializedAsync()
        {
            if (_initialized) return;

            _db = await _dbFactory.Create<FacturasDb>() ;
            _initialized = true;
        }

        public async Task AddFacturaAsync(FacturaLocal factura)
        {
            _db.Facturas.Add(factura);
            await _db.SaveChanges();
        }


        public Task<List<FacturaLocal>> GetFacturasAsync()
        {
             EnsureInitializedAsync();
            var resultado =  _db.Facturas?.ToList();
            return Task.FromResult(resultado ?? new List<FacturaLocal>());
        }


        public async Task UpdateFacturaAsync(FacturaLocal factura)
        {
            var item = _db.Facturas.SingleOrDefault(f => f.Id == factura.Id);
            if (item != null)
            {
                _db.Facturas.Remove(item);
                _db.Facturas.Add(factura);
                await _db.SaveChanges();
            }
        }

        public async Task DeleteFacturaAsync(string id)
        {
            var item = _db.Facturas.SingleOrDefault(f => f.Id == id);
            if (item != null)
            {
                _db.Facturas.Remove(item);
                await _db.SaveChanges();
            }
        }
    }




}
