using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;

[ServiceContract]
public interface IMSDNVideoServices
{

    #region "Operaciones sobre películas"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerPeliculas(bool incluirActores);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerPeliculasPorFiltro(FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones, out int total);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    Pelicula Peliculas_ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerPeliculasPendienteDevolver(string nifUsuario);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerMisPeliculasPendienteDevolver();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerPeliculasPendienteRecoger(string nifUsuario);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerMisPeliculasPendienteRecoger();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerTopPeliculasAlquiler();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerTopPeliculasVentas();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Pelicula> Peliculas_ObtenerTopPeliculasPuntuacion();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Peliculas_ActualizarPelicula(Pelicula pelicula, Pelicula original);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Peliculas_EliminarPelicula(Pelicula pelicula);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Peliculas_AgregarPelicula(Pelicula pelicula);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    byte[] Peliculas_ObtenerCaratula(string codBarras, int ancho, int alto);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Peliculas_ModificarCaratula(byte[] caratula, string codBarras);

    #endregion

    #region "Operaciones sobre ChangeSets"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void ChangeSet_ActualizarChangeSet(DisconnectedChangeSet changeSet);

    #endregion

    #region "Operaciones sobre Usuarios"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Usuario> Usuarios_ObtenerUsuarios();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Socio> Usuarios_ObtenerSocios();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Socio> Usuarios_ObtenerSociosPorNombre(string nombre);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    Usuario Usuarios_ObtenerUsuarioPorNIF(string nif);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    Usuario Usuarios_ObtenerMiUsuario();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    Socio Usuarios_ObtenerSocioPorNIF(string nif);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Usuarios_ActualizarUsuario(Usuario usuario, Usuario original);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Usuarios_EliminarUsuario(Usuario usuario);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Usuarios_AgregarUsuario(Usuario usuario);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void Usuarios_EstablecerClave(string nif, string clave);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    Usuario Usuarios_ValidarUsuario(string nifUsuario, string clave);

    #endregion

    #region "Operaciones sobre actores"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Actor> Actores_ObtenerActores();

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Actor> Actores_ObtenerActoresPorNombre(string nombre);

    #endregion

    #region "Operaciones de compras y alquileres"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido ComprarPelicula(string nifSocio, string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido ComprarMiPelicula(string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido AlquilarPelicula(string nifSocio, string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido AlquilarMiPelicula(string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido AlquilarPeliculaYRecoger(string nifSocio, string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido AlquilarMiPeliculaYRecoger(string peliculaCodBarras);


    [OperationContract]
    [ReferencePreservingDataContractFormat]
    decimal CalcularPrecioAlquiler(string nifSocio, string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    decimal CalcularMiPrecioAlquiler(string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void RecogerPelicula(string nifSocio, string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    void RecogerMiPelicula(string peliculaCodBarras);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido DevolverPelicula(string nifSocio, string peliculaCodBarras, out Historico historico);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    EstadoPedido DevolverMiPelicula(string peliculaCodBarras, out Historico historico);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula);

    #endregion

    #region "Operaciones sobre notificaciones"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<Notificacion> Notificaciones_ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula);

    #endregion

    #region "Operaciones sobre informes"

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<InformeSaldos> Informes_ObtenerInformeSaldos(out SaludInforme saludInforme);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<InformeVentas> Informes_ObtenerInformeVentas(out SaludInforme saludInforme);

    [OperationContract]
    [ReferencePreservingDataContractFormat]
    BindingList<InformeStock> Informes_ObtenerInformeStock(out SaludInforme saludInforme);

    #endregion

}
