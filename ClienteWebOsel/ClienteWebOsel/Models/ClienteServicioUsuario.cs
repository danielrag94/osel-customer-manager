using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace ClienteWebOsel.Models
{
    public class ClienteServicioUsuario
    {
        private string BASE_URL = "http://localhost:62182/Servicios/CRUD/ServicioUsuario.svc/";

        public List<Usuario> LeerTodos()
        {
            var webclient = new WebClient();
            var json = webclient.DownloadString(BASE_URL + "getAll");
            var js = new JavaScriptSerializer();
            return js.Deserialize<List<Usuario>>(json);
        }

        public Usuario LeerPorId(string id)
        {
            var webclient = new WebClient();
            string url = string.Format(BASE_URL + "get/{0}", id);
            var json = webclient.DownloadString(url);
            var js = new JavaScriptSerializer();
            return js.Deserialize<Usuario>(json);
        }

        public Usuario LeerPorNombre(string nombre)
        {
            var webclient = new WebClient();
            string url = string.Format(BASE_URL + "getByCode/{nombre}", nombre);
            var json = webclient.DownloadString(url);
            var js = new JavaScriptSerializer();
            return js.Deserialize<Usuario>(json);
        }

        public bool Crear(Usuario usuario)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, usuario);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "create", "POST", data);
            return true;
        }

        public bool Editar(Usuario usuario)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, usuario);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "edit", "PUT", data);
            return true;
        }

        public bool Eliminar(Usuario usuario)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, usuario);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "delete", "DELETE", data);
            return true;
        }
    }
}