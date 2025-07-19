
using Blazor.IndexedDB;
using Microsoft.JSInterop;



namespace ServidorWeb.Client.ModelsLocal
{

    //public class FacturasDb : IndexedDb
    //{
    //    public FacturasDb(IJSRuntime jsRuntime) : base(jsRuntime, "MiAppOfflineDB", 1)
    //    {
    //    }

    //    public IndexedSet<FacturaLocal> Facturas { get; set; } = null!;
    //}


    public class FacturasDb
    {
        private readonly IIndexedDbFactory _dbFactory;
        private IndexedDb _db;

        public FacturasDb(IIndexedDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task InitAsync()
        {
            _db = await _dbFactory.Create("FacturasDB", 1, dbStore =>
            {
                //dbStore.CreateObjectStore("clientes", store =>
                //{
                //    store.AutoIncrement = true;
                //    store.AddKey("id");
                //    store.CreateIndex("nombre", false);
                //    store.CreateIndex("correo", false);
                //});

                dbStore.CreateObjectStore("facturas", store =>
                {
                    store.AutoIncrement = true;
                    store.AddKey("Id");
                    //store.CreateIndex("clienteId", false);
                    store.CreateIndex("fecha", false);
                });
            });
        }

        //public async Task<List<Cliente>> ObtenerClientesAsync()
        //{
        //    await InitAsync();
        //    return await _db.GetAll<Cliente>("clientes");
        //}

        //public async Task AgregarClienteAsync(Cliente cliente)
        //{
        //    await InitAsync();
        //    await _db.AddRecord("clientes", cliente);
        //}
    }



}
