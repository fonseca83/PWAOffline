namespace ServidorWeb.Shared;

public static partial class RutasWeb
{
    public static partial class Paginas
    {
        
    }

    public static partial class PaginasDeEjemplo
    {
        
        public const string Weather = "/weather";
        public const string Prueba1 = "/prueba1";
        public const string Prueba2 = "/prueba2/{id}";
        public static string Prueba2Param(int id) => $"/prueba2/{id}";
#if !SinSoporteCshtml
        public const string Prueba3 = "/prueba3";
#endif
#if !SinSoporteMVC
        public const string Prueba4 = "/prueba4.loquesea.html";
#endif
    }

    public static partial class Wwwroot
    {
        
        public const string SampleDataWheather = "/sample-data/weather.json";
        public static class SampleData
        {
            public const string Root = "/sample-data";
            public const string Weather = Root+"/weather.json";
        }
        
    }
    
}