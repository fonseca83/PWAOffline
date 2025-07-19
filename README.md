# Descripcion
Este plantilla en blazor se encarga tener un ejemplo listo para Blazor 8 United, donde se tiene activado blazor server y web assembly, y el modo auto, 
# 1. Instalacion de plantilla
Descargar la plantilla y mediante el comando en la carpeta raiz
```bash
dotnet new -i .
```
esto lo instalara en tu pc y para desplegarlo solo ejecuta
```bash
dotnet new blazor -n Blazor8UnitedTemplate
```

# 2. Estructura
## 2.1 Proyectos
### 2.1.1 $ProyectName$.Shared
Archivos que seran compartidos con entre el cliente y el servidor, tomar en cuenta que en su version con web Assembly cualquier dato sera accesible desde el cliente, procurar no añadir informacion sensible
### 2.1.2 $ProyectName$.Client
Archivos Paginas o componentes que pueden trabajar en modo de WebAssembly o modo Auto , tomar como ejemplo el Counter
### 2.1.3 $ProyectName$.Server
Archivos del servidor donde solo trabajara en Modo RenderMode.InteractiveServer si existe alguna pagina o componente aca no trabajara con RenderMode.Auto ya que cualquier pagina blazor dara error

## 2.2 Enlaces deben estar dentro del proyecto $ProyectName$.Shared
Asegúrate de ubicar los enlaces dentro del proyecto $ProyectName$.Shared. Como ejemplo, considera el archivo RutasWeb.cs:
```cs
public static partial class RutasWeb
{
    public static partial class PaginasDeEjemplo
    {
        public const string Weather = "/weather";
        public const string Prueba1 = "/prueba1";
        public const string Prueba2 = "/prueba2/{id}";
        public static string Prueba2Param(int id) => $"/prueba2/{id}";
    }
}
```
En este archivo, asegúrate de incluir las constantes que representan tus enlaces. Si un enlace tiene parámetros, también crea un método equivalente con el sufijo "Param" para facilitar la construcción de esos enlaces con parámetros.