using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using MSDNVideo.Pruebas.MSDNVideoServices;
using System.Threading;
using System.Security.Principal;

namespace MSDNVideo.Pruebas
{
    class ConnectionHelper
    {
        private static IMSDNVideoServices _serviceClient;

        static ConnectionHelper()
        {
            _serviceClient = CreateCustomServiceClient("99999999R", "12345");
        }

        static public IMSDNVideoServices CreateCustomServiceClient(string userName, string password)
        {
            ChannelFactory<IMSDNVideoServices> factory = new ChannelFactory<IMSDNVideoServices>("ws");
            factory.Credentials.UserName.UserName = userName;
            factory.Credentials.UserName.Password = password;

            SetDataContractSerializerBehavior(factory.Endpoint.Contract);

            return factory.CreateChannel();
        }

        static public void ImpersonateAdmin()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("99999999R"), new string[] { "Admin" });
        }

        public static IMSDNVideoServices ServiceClient
        {
            get
            {
                return _serviceClient;
            }
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

    }
}
