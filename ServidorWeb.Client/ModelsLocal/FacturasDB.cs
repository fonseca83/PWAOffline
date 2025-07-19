
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


    public class FacturasDb : IndexedDb
    {
        public FacturasDb(IJSRuntime jsRuntime, IndexedDBManager dbManager)
            : base(jsRuntime, dbManager)
        {
        }
    }


}
