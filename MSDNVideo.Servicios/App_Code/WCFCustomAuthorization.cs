using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.Threading;

namespace MSDNVideo.Servicios
{
    /// <summary>
    /// Esta clase permite personalizar el mecanismo de autorización de WCF
    /// En nuestro caso lo usaremos para establecer la identidad del hilo
    /// De esta forma podemos autorizar con los atributos de seguridad en las operaciones
    /// </summary>
    public class WCFCustomAuthorization : IAuthorizationPolicy
    {
        #region Campos

        private Guid id = Guid.NewGuid();

        #endregion

        #region IAuthorizationPolicy Members

        /// <summary>
        /// Recupera el usuario actual y lo establece como identidad del hilo
        /// </summary>
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            string userName;

            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                // Ya se ha establecido la identidad en la cabecera de interoperabilidad
                evaluationContext.Properties["Principal"] = Thread.CurrentPrincipal;
            }
            else
            {
                IIdentity client = GetClientIdentity(evaluationContext);
                GenericIdentity customClient = client as GenericIdentity;

                if (customClient == null)
                    userName = null;
                else
                    userName = customClient.Name;

                evaluationContext.Properties["Principal"] = GestionSeguridad.ObtenerPrincipal(userName);

            }

            return true;
        }

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }


        public string Id
        {
            get { return id.ToString(); }
        }

        #endregion

        #region Métodos privados

        private IIdentity GetClientIdentity(EvaluationContext evaluationContext)
        {
            object obj;
            if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
                return null;

            IList<IIdentity> identities = obj as IList<IIdentity>;
            if (obj == null || identities.Count <= 0)
                return null;

            return identities[0];
        }

        #endregion
    }
}