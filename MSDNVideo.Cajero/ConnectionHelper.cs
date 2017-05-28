using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Cajero.MSDNVideoServices;
using System.ServiceModel.Description;
using System.ServiceModel;
using MSDNVideo.Comun;

namespace MSDNVideo.Cajero
{
    /// <summary>
    ///  Clase auxiliar para acceder a los servicios web de la aplicación
    /// </summary>
    class ConnectionHelper
    {
        private static IMSDNVideoServices _serviceClient;

        static ConnectionHelper()
        {
            // Por defecto nos conectamos en modo anónimo
            ChannelFactory<IMSDNVideoServices> factory = new ChannelFactory<IMSDNVideoServices>("ws");

            factory.Credentials.UserName.UserName = "invitado";
            factory.Credentials.UserName.Password = "";

            SetDataContractSerializerBehavior(factory.Endpoint.Contract);

            _serviceClient = factory.CreateChannel();
        }

        public static bool SetConnectionData(string usuario, string clave, string address, out string errorMessage)
        {
            ChannelFactory<IMSDNVideoServices> factory = new ChannelFactory<IMSDNVideoServices>("ws");
            IMSDNVideoServices serviceClient;
            Usuario usuarioEntity = null;

            errorMessage = null;
            
            if(address != null)
                factory.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri(address), factory.Endpoint.Address.Identity, factory.Endpoint.Address.Headers);
            
            factory.Credentials.UserName.UserName = "invitado";
            factory.Credentials.UserName.Password = "";

            SetDataContractSerializerBehavior(factory.Endpoint.Contract);

            serviceClient = factory.CreateChannel();

            try
            {
                usuarioEntity = serviceClient.Usuarios_ValidarUsuario(usuario, clave);
            }
            catch (Exception)
            {
                errorMessage = "Error conectando con el servidor";
                return false;
            }

            if (usuarioEntity == null)
            {
                errorMessage = "El usuario o la clave son incorrectos";
                return false;
            }

            if (usuarioEntity.Rol != Rol.Socio)
            {
                errorMessage = "El usuario introducido no es socio";
                return false;
            }

            factory = new ChannelFactory<IMSDNVideoServices>("ws");

            if (address != null)
                factory.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri(address), factory.Endpoint.Address.Identity, factory.Endpoint.Address.Headers);

            factory.Credentials.UserName.UserName = usuario;
            factory.Credentials.UserName.Password = clave;

            SetDataContractSerializerBehavior(factory.Endpoint.Contract);

            _serviceClient = factory.CreateChannel();

            return true;
        }

        private static void SetDataContractSerializerBehavior(ContractDescription contractDescription)
        {
            foreach (OperationDescription operation in contractDescription.Operations)
            {
                for (int i = 0; i < operation.Behaviors.Count; i++)
                {
                    if (operation.Behaviors[i] is DataContractSerializerOperationBehavior)
                        operation.Behaviors[i] = new ReferencePreservingDataContractSerializerOperationBehavior(operation);
                }
            }
        }

        public static IMSDNVideoServices ServiceClient
        {
            get
            {
                return _serviceClient;
            }
        }
    }
}
