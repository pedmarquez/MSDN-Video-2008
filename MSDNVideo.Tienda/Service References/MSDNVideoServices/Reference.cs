﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSDNVideo.Tienda.MSDNVideoServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MSDNVideoServices.IMSDNVideoServices")]
    public interface IMSDNVideoServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculas", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculas(bool incluirActores);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPorFiltro", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPorFiltroResponse" +
            "")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPorFiltro(out int total, MSDNVideo.Comun.FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculaPorCodBarras", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculaPorCodBarrasRespon" +
            "se")]
        MSDNVideo.Comun.Pelicula Peliculas_ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPendienteDevolver" +
            "", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPendienteDevolver" +
            "Response")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPendienteDevolver(string nifUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerMisPeliculasPendienteDevol" +
            "ver", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerMisPeliculasPendienteDevol" +
            "verResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerMisPeliculasPendienteDevolver();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPendienteRecoger", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerPeliculasPendienteRecogerR" +
            "esponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPendienteRecoger(string nifUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerMisPeliculasPendienteRecog" +
            "er", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerMisPeliculasPendienteRecog" +
            "erResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerMisPeliculasPendienteRecoger();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasAlquiler", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasAlquilerRespon" +
            "se")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasAlquiler();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasVentas", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasVentasResponse" +
            "")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasVentas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasPuntuacion", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerTopPeliculasPuntuacionResp" +
            "onse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasPuntuacion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ActualizarPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ActualizarPeliculaResponse")]
        void Peliculas_ActualizarPelicula(MSDNVideo.Comun.Pelicula pelicula, MSDNVideo.Comun.Pelicula original);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_EliminarPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_EliminarPeliculaResponse")]
        void Peliculas_EliminarPelicula(MSDNVideo.Comun.Pelicula pelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_AgregarPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_AgregarPeliculaResponse")]
        void Peliculas_AgregarPelicula(MSDNVideo.Comun.Pelicula pelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerCaratula", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ObtenerCaratulaResponse")]
        byte[] Peliculas_ObtenerCaratula(string codBarras, int ancho, int alto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Peliculas_ModificarCaratula", ReplyAction="http://tempuri.org/IMSDNVideoServices/Peliculas_ModificarCaratulaResponse")]
        void Peliculas_ModificarCaratula(byte[] caratula, string codBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/ChangeSet_ActualizarChangeSet", ReplyAction="http://tempuri.org/IMSDNVideoServices/ChangeSet_ActualizarChangeSetResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Pelicula))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Clasificaciones))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Generos))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.ActoresPelicula>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.ActoresPelicula))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Actor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Alquiler>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Alquiler))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Notificacion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Notificacion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.TipoNotificacion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Puntuacion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Puntuacion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Historico>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Historico))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.TipoOperacion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.FiltroPeliculas))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.CamposFiltro))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Usuario>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Socio>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.Actor>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.EstadoPedido))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.InformeSaldos>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.InformeSaldos))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.SaludInforme))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.InformeVentas>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.InformeVentas))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<MSDNVideo.Comun.InformeStock>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.InformeStock))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ComponentModel.BindingList<object>))]
        void ChangeSet_ActualizarChangeSet(MSDNVideo.Comun.DisconnectedChangeSet changeSet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerUsuarios", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerUsuariosResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Usuario> Usuarios_ObtenerUsuarios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSocios", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSociosResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Socio> Usuarios_ObtenerSocios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSociosPorNombre", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSociosPorNombreResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Socio> Usuarios_ObtenerSociosPorNombre(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerUsuarioPorNIF", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerUsuarioPorNIFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        MSDNVideo.Comun.Usuario Usuarios_ObtenerUsuarioPorNIF(string nif);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerMiUsuario", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerMiUsuarioResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        MSDNVideo.Comun.Usuario Usuarios_ObtenerMiUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSocioPorNIF", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ObtenerSocioPorNIFResponse")]
        MSDNVideo.Comun.Socio Usuarios_ObtenerSocioPorNIF(string nif);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ActualizarUsuario", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ActualizarUsuarioResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        void Usuarios_ActualizarUsuario(MSDNVideo.Comun.Usuario usuario, MSDNVideo.Comun.Usuario original);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_EliminarUsuario", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_EliminarUsuarioResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        void Usuarios_EliminarUsuario(MSDNVideo.Comun.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_AgregarUsuario", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_AgregarUsuarioResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        void Usuarios_AgregarUsuario(MSDNVideo.Comun.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_EstablecerClave", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_EstablecerClaveResponse")]
        void Usuarios_EstablecerClave(string nif, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Usuarios_ValidarUsuario", ReplyAction="http://tempuri.org/IMSDNVideoServices/Usuarios_ValidarUsuarioResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Socio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MSDNVideo.Comun.Admin))]
        MSDNVideo.Comun.Usuario Usuarios_ValidarUsuario(string nifUsuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Actores_ObtenerActores", ReplyAction="http://tempuri.org/IMSDNVideoServices/Actores_ObtenerActoresResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Actor> Actores_ObtenerActores();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Actores_ObtenerActoresPorNombre", ReplyAction="http://tempuri.org/IMSDNVideoServices/Actores_ObtenerActoresPorNombreResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Actor> Actores_ObtenerActoresPorNombre(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/ComprarPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/ComprarPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido ComprarPelicula(string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/ComprarMiPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/ComprarMiPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido ComprarMiPelicula(string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/AlquilarPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/AlquilarPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido AlquilarPelicula(string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/AlquilarMiPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/AlquilarMiPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido AlquilarMiPelicula(string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/AlquilarPeliculaYRecoger", ReplyAction="http://tempuri.org/IMSDNVideoServices/AlquilarPeliculaYRecogerResponse")]
        MSDNVideo.Comun.EstadoPedido AlquilarPeliculaYRecoger(string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/AlquilarMiPeliculaYRecoger", ReplyAction="http://tempuri.org/IMSDNVideoServices/AlquilarMiPeliculaYRecogerResponse")]
        MSDNVideo.Comun.EstadoPedido AlquilarMiPeliculaYRecoger(string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/CalcularPrecioAlquiler", ReplyAction="http://tempuri.org/IMSDNVideoServices/CalcularPrecioAlquilerResponse")]
        decimal CalcularPrecioAlquiler(string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/CalcularMiPrecioAlquiler", ReplyAction="http://tempuri.org/IMSDNVideoServices/CalcularMiPrecioAlquilerResponse")]
        decimal CalcularMiPrecioAlquiler(string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/RecogerPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/RecogerPeliculaResponse")]
        void RecogerPelicula(string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/RecogerMiPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/RecogerMiPeliculaResponse")]
        void RecogerMiPelicula(string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/DevolverPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/DevolverPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido DevolverPelicula(out MSDNVideo.Comun.Historico historico, string nifSocio, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/DevolverMiPelicula", ReplyAction="http://tempuri.org/IMSDNVideoServices/DevolverMiPeliculaResponse")]
        MSDNVideo.Comun.EstadoPedido DevolverMiPelicula(out MSDNVideo.Comun.Historico historico, string peliculaCodBarras);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/ObtenerAlquileresSinDevolver", ReplyAction="http://tempuri.org/IMSDNVideoServices/ObtenerAlquileresSinDevolverResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/ObtenerAlquileresSinRecoger", ReplyAction="http://tempuri.org/IMSDNVideoServices/ObtenerAlquileresSinRecogerResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Notificaciones_ObtenerNotificaciones", ReplyAction="http://tempuri.org/IMSDNVideoServices/Notificaciones_ObtenerNotificacionesRespons" +
            "e")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.Notificacion> Notificaciones_ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeSaldos", ReplyAction="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeSaldosResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.InformeSaldos> Informes_ObtenerInformeSaldos(out MSDNVideo.Comun.SaludInforme saludInforme);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeVentas", ReplyAction="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeVentasResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.InformeVentas> Informes_ObtenerInformeVentas(out MSDNVideo.Comun.SaludInforme saludInforme);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeStock", ReplyAction="http://tempuri.org/IMSDNVideoServices/Informes_ObtenerInformeStockResponse")]
        System.ComponentModel.BindingList<MSDNVideo.Comun.InformeStock> Informes_ObtenerInformeStock(out MSDNVideo.Comun.SaludInforme saludInforme);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMSDNVideoServicesChannel : MSDNVideo.Tienda.MSDNVideoServices.IMSDNVideoServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MSDNVideoServicesClient : System.ServiceModel.ClientBase<MSDNVideo.Tienda.MSDNVideoServices.IMSDNVideoServices>, MSDNVideo.Tienda.MSDNVideoServices.IMSDNVideoServices {
        
        public MSDNVideoServicesClient() {
        }
        
        public MSDNVideoServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MSDNVideoServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MSDNVideoServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MSDNVideoServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculas(bool incluirActores) {
            return base.Channel.Peliculas_ObtenerPeliculas(incluirActores);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPorFiltro(out int total, MSDNVideo.Comun.FiltroPeliculas filtro, bool incluirActores, bool incluirPuntuaciones) {
            return base.Channel.Peliculas_ObtenerPeliculasPorFiltro(out total, filtro, incluirActores, incluirPuntuaciones);
        }
        
        public MSDNVideo.Comun.Pelicula Peliculas_ObtenerPeliculaPorCodBarras(string codBarras, bool incluirActores, bool incluirPuntuacionMedia) {
            return base.Channel.Peliculas_ObtenerPeliculaPorCodBarras(codBarras, incluirActores, incluirPuntuacionMedia);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPendienteDevolver(string nifUsuario) {
            return base.Channel.Peliculas_ObtenerPeliculasPendienteDevolver(nifUsuario);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerMisPeliculasPendienteDevolver() {
            return base.Channel.Peliculas_ObtenerMisPeliculasPendienteDevolver();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerPeliculasPendienteRecoger(string nifUsuario) {
            return base.Channel.Peliculas_ObtenerPeliculasPendienteRecoger(nifUsuario);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerMisPeliculasPendienteRecoger() {
            return base.Channel.Peliculas_ObtenerMisPeliculasPendienteRecoger();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasAlquiler() {
            return base.Channel.Peliculas_ObtenerTopPeliculasAlquiler();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasVentas() {
            return base.Channel.Peliculas_ObtenerTopPeliculasVentas();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Pelicula> Peliculas_ObtenerTopPeliculasPuntuacion() {
            return base.Channel.Peliculas_ObtenerTopPeliculasPuntuacion();
        }
        
        public void Peliculas_ActualizarPelicula(MSDNVideo.Comun.Pelicula pelicula, MSDNVideo.Comun.Pelicula original) {
            base.Channel.Peliculas_ActualizarPelicula(pelicula, original);
        }
        
        public void Peliculas_EliminarPelicula(MSDNVideo.Comun.Pelicula pelicula) {
            base.Channel.Peliculas_EliminarPelicula(pelicula);
        }
        
        public void Peliculas_AgregarPelicula(MSDNVideo.Comun.Pelicula pelicula) {
            base.Channel.Peliculas_AgregarPelicula(pelicula);
        }
        
        public byte[] Peliculas_ObtenerCaratula(string codBarras, int ancho, int alto) {
            return base.Channel.Peliculas_ObtenerCaratula(codBarras, ancho, alto);
        }
        
        public void Peliculas_ModificarCaratula(byte[] caratula, string codBarras) {
            base.Channel.Peliculas_ModificarCaratula(caratula, codBarras);
        }
        
        public void ChangeSet_ActualizarChangeSet(MSDNVideo.Comun.DisconnectedChangeSet changeSet) {
            base.Channel.ChangeSet_ActualizarChangeSet(changeSet);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Usuario> Usuarios_ObtenerUsuarios() {
            return base.Channel.Usuarios_ObtenerUsuarios();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Socio> Usuarios_ObtenerSocios() {
            return base.Channel.Usuarios_ObtenerSocios();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Socio> Usuarios_ObtenerSociosPorNombre(string nombre) {
            return base.Channel.Usuarios_ObtenerSociosPorNombre(nombre);
        }
        
        public MSDNVideo.Comun.Usuario Usuarios_ObtenerUsuarioPorNIF(string nif) {
            return base.Channel.Usuarios_ObtenerUsuarioPorNIF(nif);
        }
        
        public MSDNVideo.Comun.Usuario Usuarios_ObtenerMiUsuario() {
            return base.Channel.Usuarios_ObtenerMiUsuario();
        }
        
        public MSDNVideo.Comun.Socio Usuarios_ObtenerSocioPorNIF(string nif) {
            return base.Channel.Usuarios_ObtenerSocioPorNIF(nif);
        }
        
        public void Usuarios_ActualizarUsuario(MSDNVideo.Comun.Usuario usuario, MSDNVideo.Comun.Usuario original) {
            base.Channel.Usuarios_ActualizarUsuario(usuario, original);
        }
        
        public void Usuarios_EliminarUsuario(MSDNVideo.Comun.Usuario usuario) {
            base.Channel.Usuarios_EliminarUsuario(usuario);
        }
        
        public void Usuarios_AgregarUsuario(MSDNVideo.Comun.Usuario usuario) {
            base.Channel.Usuarios_AgregarUsuario(usuario);
        }
        
        public void Usuarios_EstablecerClave(string nif, string clave) {
            base.Channel.Usuarios_EstablecerClave(nif, clave);
        }
        
        public MSDNVideo.Comun.Usuario Usuarios_ValidarUsuario(string nifUsuario, string clave) {
            return base.Channel.Usuarios_ValidarUsuario(nifUsuario, clave);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Actor> Actores_ObtenerActores() {
            return base.Channel.Actores_ObtenerActores();
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Actor> Actores_ObtenerActoresPorNombre(string nombre) {
            return base.Channel.Actores_ObtenerActoresPorNombre(nombre);
        }
        
        public MSDNVideo.Comun.EstadoPedido ComprarPelicula(string nifSocio, string peliculaCodBarras) {
            return base.Channel.ComprarPelicula(nifSocio, peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido ComprarMiPelicula(string peliculaCodBarras) {
            return base.Channel.ComprarMiPelicula(peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido AlquilarPelicula(string nifSocio, string peliculaCodBarras) {
            return base.Channel.AlquilarPelicula(nifSocio, peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido AlquilarMiPelicula(string peliculaCodBarras) {
            return base.Channel.AlquilarMiPelicula(peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido AlquilarPeliculaYRecoger(string nifSocio, string peliculaCodBarras) {
            return base.Channel.AlquilarPeliculaYRecoger(nifSocio, peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido AlquilarMiPeliculaYRecoger(string peliculaCodBarras) {
            return base.Channel.AlquilarMiPeliculaYRecoger(peliculaCodBarras);
        }
        
        public decimal CalcularPrecioAlquiler(string nifSocio, string peliculaCodBarras) {
            return base.Channel.CalcularPrecioAlquiler(nifSocio, peliculaCodBarras);
        }
        
        public decimal CalcularMiPrecioAlquiler(string peliculaCodBarras) {
            return base.Channel.CalcularMiPrecioAlquiler(peliculaCodBarras);
        }
        
        public void RecogerPelicula(string nifSocio, string peliculaCodBarras) {
            base.Channel.RecogerPelicula(nifSocio, peliculaCodBarras);
        }
        
        public void RecogerMiPelicula(string peliculaCodBarras) {
            base.Channel.RecogerMiPelicula(peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido DevolverPelicula(out MSDNVideo.Comun.Historico historico, string nifSocio, string peliculaCodBarras) {
            return base.Channel.DevolverPelicula(out historico, nifSocio, peliculaCodBarras);
        }
        
        public MSDNVideo.Comun.EstadoPedido DevolverMiPelicula(out MSDNVideo.Comun.Historico historico, string peliculaCodBarras) {
            return base.Channel.DevolverMiPelicula(out historico, peliculaCodBarras);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Alquiler> ObtenerAlquileresSinDevolver(bool incluirSocio, bool incluirPelicula) {
            return base.Channel.ObtenerAlquileresSinDevolver(incluirSocio, incluirPelicula);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Alquiler> ObtenerAlquileresSinRecoger(bool incluirSocio, bool incluirPelicula) {
            return base.Channel.ObtenerAlquileresSinRecoger(incluirSocio, incluirPelicula);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.Notificacion> Notificaciones_ObtenerNotificaciones(bool incluirSocio, bool incluirPelicula) {
            return base.Channel.Notificaciones_ObtenerNotificaciones(incluirSocio, incluirPelicula);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.InformeSaldos> Informes_ObtenerInformeSaldos(out MSDNVideo.Comun.SaludInforme saludInforme) {
            return base.Channel.Informes_ObtenerInformeSaldos(out saludInforme);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.InformeVentas> Informes_ObtenerInformeVentas(out MSDNVideo.Comun.SaludInforme saludInforme) {
            return base.Channel.Informes_ObtenerInformeVentas(out saludInforme);
        }
        
        public System.ComponentModel.BindingList<MSDNVideo.Comun.InformeStock> Informes_ObtenerInformeStock(out MSDNVideo.Comun.SaludInforme saludInforme) {
            return base.Channel.Informes_ObtenerInformeStock(out saludInforme);
        }
    }
}
