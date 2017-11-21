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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPintura" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPintura
    {
        [OperationContract]
        [WebInvoke( Method = "POST", UriTemplate = "create", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        bool Crear(Pintura pintura);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAll", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Pintura> LeerTodos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getByCode/{codigo}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Pintura LeerPorCodigo(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Pintura LeerPorId(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Editar(Pintura pintura);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Eliminar(Pintura paint);
    }
}
