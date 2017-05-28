using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Tienda.MSDNVideoServices;
using System.ServiceModel;
using MSDNVideo.Comun;
using System.ServiceModel.Description;

namespace MSDNVideo.Tienda
{
    /// <summary>
    ///  Clase auxiliar para acceder a los servicios web de la aplicación
    /// </summary>
    class ConnectionHelper
    {
        private static IMSDNVideoServices _serviceClient;

        static ConnectionHelper()
        {
        }

        public static bool SetConnectionData(string usuario, string clave, string address, out string errorMessage)
        {
            ChannelFactory<IMSDNVideoServices> factory = new ChannelFactory<IMSDNVideoServices>("ws");
            IMSDNVideoServices serviceClient;
            Usuario usuarioEntity = null;

            errorMessage = null;
            factory.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri(address), factory.Endpoint.Address.Identity, factory.Endpoint.Address.Headers);
            factory.Credentials.UserName.UserName = "invitado";
            factory.Credentials.UserName.Password = "";

            SetDataContractSerializerBehavior(factory.Endpoint.Contract);

            serviceClient = factory.CreateChannel();

            try
            {
                usuarioEntity = serviceClient.Usuarios_ValidarUsuario(usuario, clave);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

            if (usuarioEntity == null)
            {
                errorMessage = "El usuario o la clave son incorrectos";
                return false;
            }

            if (usuarioEntity.Rol != Rol.Admin)
            {
                errorMessage = "El usuario suministrado no es administrador";
                return false;
            }

            factory = new ChannelFactory<IMSDNVideoServices>("ws");
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
