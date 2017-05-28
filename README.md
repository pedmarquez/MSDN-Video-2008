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
