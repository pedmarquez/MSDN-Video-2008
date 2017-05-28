using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security;
using System.ServiceModel;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.Threading;

namespace MSDNVideo.Servicios
{
    public class WCFUserValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if(!GestionSeguridad.ValidarUsuario(userName, password))
                throw new SecurityTokenException("Nombre de usuario o contraseña no válidos");
        }
    }
}
