using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosOsel.Servicios.Sesion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioSesion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSesion
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "encriptar/{contrasena}", ResponseFormat = WebMessageFormat.Json)]
        string Encriptar(string constrasena);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "desencriptar/{contrasena}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Desencriptar(string contrasena);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "logout", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Logout();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "login/{email},{password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Login(string email, string password);

    }
}
