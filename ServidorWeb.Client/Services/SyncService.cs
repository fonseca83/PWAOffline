using System.Net.Http.Json;

namespace ServidorWeb.Client.Services
{
    public class SyncService
    {
        private readonly HttpClient _http;
        private readonly FacturaService _localDb;

        public SyncService(HttpClient http, FacturaService localDb)
        {
            _http = http;
            _localDb = localDb;
        }

        public async Task SincronizarAsync()
        {
            var facturas = await _localDb.GetFacturasAsync();
            var noSincronizadas = facturas.Where(f => !f.IsSynced).ToList();

            if (noSincronizadas.Any())
            {
                var response = await _http.PostAsJsonAsync("api/facturas/sync", noSincronizadas);
                if (response.IsSuccessStatusCode)
                {
                    foreach (var f in noSincronizadas)
                    {
                        f.IsSynced = true;
                        await _localDb.UpdateFacturaAsync(f);
                    }
                }
            }
        }
    }


}
