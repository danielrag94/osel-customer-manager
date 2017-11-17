using ServiciosOsel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosOsel.Servicios.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioOrden" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioOrden
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Crear(Orden orden);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAll", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Orden> LeerTodos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Orden LeerPorId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFecha/{fecha}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Orden LeerPorFecha(string fecha);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Editar(Orden orden);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Eliminar(Orden order);
    }
}
