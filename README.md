
# ¡Bienvenido!
MSDN Video 2008 es una iniciativa de MSDN España con la que puedes aprender las últimas tecnologías de .NET aplicadas a un desarrollo real de una implementación ficticia de un videoclub.

Su funcionalidad, aunque básica, es muy común con otras aplicaciones empresariales:
- Gestión de usuarios (socios, administradores) y permisos. 
- Gestión de artículos (catálogo de películas) 
- Gestión de lógica de negocio (stocks, ventas y alquileres) 

Utiliza las últimas tecnologías de .NET 3.5 aplicadas de forma integrada en la misma solución:
- **LINQ:** acceso a datos y la creación de entidades. 
- **Windows Communication Foundation:** exposición de los servicios. 
- **ASP.NET 3.5, AJAX, Silverlight:** creación del sitio web del videoclub. 
- **Windows Forms 3.5:** herramienta de administración para gerentes de tienda. 
- **Windows Presentation Foundation:** cajero automático en tiendas. 

En este [video](https://channel9.msdn.com/blogs/eliseta/msdn-video-2008), presentamos un paseo por la funcionalidad de la aplicación. 


# Instalación manual de MSDN VIDEO 2008
## Crear base de datos
MSDN Video 2008 utiliza una base de datos que tiene que adjuntar a un servidor SQL Server. Para adjuntar la base de datos utilice la consola de administración de SQL Server.

# Modificar cadenas de conexión
MSDN Video 2008 buscará por defecto su base de datos en la instancia “(localdb)\mssqllocaldb” del servidor SQL Server local. Si la instancia de su servidor de datos es otra deberá cambiar los archivos de configuración siguientes:
-	Archivo “MSDNVideo.Web\web.config”.
-	Archivo “MSDNVideo.Servicios\web.config”
Abra ambos archivos con un editor de texto y busque el elemento XML “<connectionStrings>”. Modifique el atributo “connectionString”, especificando la instancia donde se encuentra su base de datos. Por ejemplo, si su base de datos se encuentra en la instancia por defecto el elemento XML sería el siguiente:
```
<add name="MSDNVideo.Comun.Properties.Settings.MSDNVideoConnectionString" connectionString="Data Source=.;Database=MSDNVideoDB;Integrated Security=True;Connect Timeout=30" providerName="System.Data.SqlClient"/>
```

# Instalar certificado digital
MSDN Video 2008 utiliza un certificado digital para las comunicaciones seguras por servicios web. Para instalar este certificado digital abra la consola de administración MMC (menú Inicio / Ejecutar / mmc.exe). A continuación seleccione la opción de agregar un complemento (archivo / agregar o eliminar completos) y agregue el complemento “Certificados” para el usuario actual:

Para añadir el certificado de MSDN Video pinche con el botón derecho en el elemento “Personas de confianza” y seleccione la opción “todas las tareas / importar”. En el asistente mostrado, especifique el archivo de certificado “MSDNVideoCert.pfx”, escriba como contraseña “msdnvideo” y finalice el asistente.

# Probar la aplicación
Abra el archivo de solución de MSDN Video con Visual Studio 2015 (MSDNVideo2015 - CS - LINQ.sln”. Esta solución contiene todo el código fuente de MSDN Video. Para depurar un proyecto de MSDN Video 2008 establezca el proyecto como proyecto por defecto (botón derecho sobre el proyecto / Establecer como proyecto de inicio). A continuación depure la solución (Depurar / Iniciar depuración o pulsando F5). Puede ejecutar los siguientes proyectos de MSDN Video 2008:
-	MSDNVideo.Web: Tienda online de MSDN Video.
-	MSDNVideo.Cajero: Cliente WPF para el cajero automático.
-	MSDNVideo.Tienda: Cliente Windows Forms para administración de tienda.
También dispone de un proyecto de pruebas unitarias “MSDNVideo.Pruebas” que podrá ejecutar si dispone de una versión de Visual Studio que incluya pruebas.
