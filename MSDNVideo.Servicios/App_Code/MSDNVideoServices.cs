using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;
using MSDNVideo.Servicios;

public class MSDNVideoServices : IMSDNVideoServices
{
    #region "Operaciones sobre películas"

    public BindingList<Pelicula> Peliculas_ObtenerPeliculas(bool incluirActores)
    {
        PeliculasCN peliculasCN = new PeliculasCN();

        return peliculasCN.ObtenerPeliculas(incluirActores);
    }

    public BindingList<Pelicula> Peliculas_ObtenerPeliculasPorFiltro(FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones, out int total)
    {
        PeliculasCN peliculasCN = new PeliculasCN();

        return peliculasCN.ObtenerPeliculasPorFiltro(filtro, incluirActores, incluirPuntuaciones, out total);
    }

    public Pelicula Peliculas_ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerPeliculaPorCodBarras(codBarras, incluirActores, incluirPuntuacionMedia);
    }

    public BindingList<Pelicula> Peliculas_ObtenerPeliculasPendienteDevolver(string nifUsuario)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerPeliculasPendienteDevolver(nifUsuario);
    }

    public BindingList<Pelicula> Peliculas_ObtenerMisPeliculasPendienteDevolver()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerMisPeliculasPendienteDevolver();
    }

    public BindingList<Pelicula> Peliculas_ObtenerPeliculasPendienteRecoger(string nifUsuario)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerPeliculasPendienteRecoger(nifUsuario);
    }

    public BindingList<Pelicula> Peliculas_ObtenerMisPeliculasPendienteRecoger()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerMisPeliculasPendienteRecoger();
    }

    public BindingList<Pelicula> Peliculas_ObtenerTopPeliculasAlquiler()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerTopPeliculasAlquiler();
    }

    public BindingList<Pelicula> Peliculas_ObtenerTopPeliculasVentas()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerTopPeliculasVentas();
    }

    public BindingList<Pelicula> Peliculas_ObtenerTopPeliculasPuntuacion()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerTopPeliculasPuntuacion();
    }

    public void Peliculas_ActualizarPelicula(Pelicula pelicula, Pelicula original)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        peliculasCN.ActualizarPelicula(pelicula, original);
    }

    public void Peliculas_EliminarPelicula(Pelicula pelicula)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        peliculasCN.EliminarPelicula(pelicula);
    }

    public void Peliculas_AgregarPelicula(Pelicula pelicula)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        peliculasCN.AgregarPelicula(pelicula);
    }

    public byte[] Peliculas_ObtenerCaratula(string codBarras, int ancho, int alto)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        return peliculasCN.ObtenerCaratula(codBarras, ancho, alto);
    }

    public void Peliculas_ModificarCaratula(byte[] caratula, string codBarras)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        peliculasCN.ModificarCaratula(caratula, codBarras);
    }

    #endregion

    #region "Operaciones sobre ChangeSets"

    public void ChangeSet_ActualizarChangeSet(DisconnectedChangeSet changeSet)
    {
        ChangeSetCN changeSetCN = new ChangeSetCN();
        changeSetCN.ActualizarChangeSet(changeSet);
    }

    #endregion

    #region "Operaciones sobre Usuarios"

    public BindingList<Usuario> Usuarios_ObtenerUsuarios()
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerUsuarios();
    }

    public BindingList<Socio> Usuarios_ObtenerSociosPorNombre(string nombre)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerSociosPorNombre(nombre);
    }

    public BindingList<Socio> Usuarios_ObtenerSocios()
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerSocios();
    }

    public Usuario Usuarios_ObtenerUsuarioPorNIF(string nif)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerUsuarioPorNIF(nif);
    }

    public Usuario Usuarios_ObtenerMiUsuario()
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerMiUsuario();
    }

    public Socio Usuarios_ObtenerSocioPorNIF(string nif)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ObtenerSocioPorNIF(nif);
    }

    public void Usuarios_ActualizarUsuario(Usuario usuario, Usuario original)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        usuariosCN.ActualizarUsuario(usuario, original);
    }

    public void Usuarios_EliminarUsuario(Usuario usuario)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        usuariosCN.EliminarUsuario(usuario);
    }

    public void Usuarios_AgregarUsuario(Usuario usuario)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        usuariosCN.AgregarUsuario(usuario);
    }

    public void Usuarios_EstablecerClave(string nif, string clave)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        usuariosCN.EstablecerClave(nif, clave);
    }

    public Usuario Usuarios_ValidarUsuario(string nifUsuario, string clave)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return usuariosCN.ValidarUsuario(nifUsuario, clave);
    }

    #endregion

    #region "Operaciones sobre actores"

    public BindingList<Actor> Actores_ObtenerActores()
    {
        ActoresCN actoresCN = new ActoresCN();

        return actoresCN.ObtenerActores();
    }

    public BindingList<Actor> Actores_ObtenerActoresPorNombre(string nombre)
    {
        ActoresCN actoresCN = new ActoresCN();

        return actoresCN.ObtenerActoresPorNombre(nombre);
    }

    #endregion

    #region "Operaciones de compras y alquileres"

    public EstadoPedido ComprarPelicula(string nifSocio, string peliculaCodBarras)
    {
        ComprasCN comprasCN = new ComprasCN();

        return comprasCN.ComprarPelicula(nifSocio, peliculaCodBarras);
    }

    public EstadoPedido ComprarMiPelicula(string peliculaCodBarras)
    {
        ComprasCN comprasCN = new ComprasCN();

        return comprasCN.ComprarMiPelicula(peliculaCodBarras);
    }

    public EstadoPedido AlquilarPelicula(string nifSocio, string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.AlquilarPelicula(nifSocio, peliculaCodBarras);
    }

    public EstadoPedido AlquilarMiPelicula(string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.AlquilarMiPelicula(peliculaCodBarras);
    }

    public EstadoPedido AlquilarPeliculaYRecoger(string nifSocio, string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.AlquilarPeliculaYRecoger(nifSocio, peliculaCodBarras);
    }

    public EstadoPedido AlquilarMiPeliculaYRecoger(string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.AlquilarMiPeliculaYRecoger(peliculaCodBarras);
    }

    public decimal CalcularPrecioAlquiler(string nifSocio, string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.CalcularPrecioAlquiler(nifSocio, peliculaCodBarras);
    }

    public decimal CalcularMiPrecioAlquiler(string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.CalcularMiPrecioAlquiler(peliculaCodBarras);
    }

    public void RecogerPelicula(string nifSocio, string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        alquileresCN.RecogerPelicula(nifSocio, peliculaCodBarras);
    }

    public void RecogerMiPelicula(string peliculaCodBarras)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        alquileresCN.RecogerMiPelicula(peliculaCodBarras);
    }

    public EstadoPedido DevolverPelicula(string nifSocio, string peliculaCodBarras, out Historico historico)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.DevolverPelicula(nifSocio, peliculaCodBarras, out historico);
    }

    public EstadoPedido DevolverMiPelicula(string peliculaCodBarras, out Historico historico)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.DevolverMiPelicula(peliculaCodBarras, out historico);
    }

    public BindingList<Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.ObtenerAlquileresSinDevolver(incluirSocio, incluirPelicula);
    }

    public BindingList<Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula)
    {
        AlquileresCN alquileresCN = new AlquileresCN();

        return alquileresCN.ObtenerAlquileresSinRecoger(incluirSocio, incluirPelicula);
    }

    #endregion

    #region "Operaciones sobre notificaciones"

    public BindingList<Notificacion> Notificaciones_ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula)
    {
        NotificacionesCN notificacionesCN = new NotificacionesCN();

        return notificacionesCN.ObtenerNotificaciones(incluirSocio, incluirPelicula);
    }

    #endregion

    #region "Operaciones sobre informes"

    public BindingList<InformeSaldos> Informes_ObtenerInformeSaldos(out SaludInforme saludInforme)
    {
        InformesCN informesCN = new InformesCN();

        return informesCN.ObtenerInformeSaldos(out saludInforme);
    }

    public BindingList<InformeVentas> Informes_ObtenerInformeVentas(out SaludInforme saludInforme)
    {
        InformesCN informesCN = new InformesCN();

        return informesCN.ObtenerInformeVentas(out saludInforme);
    }

    public BindingList<InformeStock> Informes_ObtenerInformeStock(out SaludInforme saludInforme)
    {
        InformesCN informesCN = new InformesCN();

        return informesCN.ObtenerInformeStock(out saludInforme);
    }

    #endregion
}
