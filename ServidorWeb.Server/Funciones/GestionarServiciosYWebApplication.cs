namespace ServidorWeb.Server.Funciones;

public static class GestionarServiciosYWebApplication
{
    static private Queue<Action<IServiceCollection>> _servicios = new();
    static private Queue<Action<WebApplication>> _usos = new();
    static public void Add(Action<IServiceCollection> servicio , Action<WebApplication> uso)
    {
        _servicios.Enqueue(servicio);
        _usos.Enqueue(uso);
    }

    static public void Add(Action<IServiceCollection> servicio) => _servicios.Enqueue(servicio);
    static public void Add(Action<WebApplication> uso) => _usos.Enqueue(uso);
    static public void AgregarServiciosCustomizados(this IServiceCollection servicios)
    {
        while (_servicios.Count > 0)
           _servicios.Dequeue()(servicios);
        
    }
    static public void AgregarUsosCustomizados(this WebApplication usos)
    {
        while (_usos.Count > 0)
            _usos.Dequeue()(usos);
    }
}