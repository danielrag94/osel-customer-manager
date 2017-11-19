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
    public class ClienteServicioPintura
    {
        private string BASE_URL = "http://localhost:62182/Servicios/CRUD/ServicioPintura.svc/";

        public List<Pintura> LeerTodos()
        {            
            var webclient = new WebClient();
            var json = webclient.DownloadString(BASE_URL + "getAll");
            var js = new JavaScriptSerializer();
            return js.Deserialize<List<Pintura>>(json);            
        }

        public Pintura LeerPorId(string id)
        {            
            var webclient = new WebClient();
            string url = string.Format(BASE_URL + "get/{0}", id);
            var json = webclient.DownloadString(url);
            var js = new JavaScriptSerializer();
            return js.Deserialize<Pintura>(json);            
        }

        public Pintura LeerPorCodigo(string codigo)
        {
            var webclient = new WebClient();
            string url = string.Format(BASE_URL + "getByCode/{codigo}", codigo);
            var json = webclient.DownloadString(url);
            var js = new JavaScriptSerializer();
            return js.Deserialize<Pintura>(json);            
        }

        public bool Crear(Pintura pintura)
        {            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, pintura);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "create", "POST", data);
            return true;            
        }

        public bool Editar(Pintura pintura)
        {            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, pintura);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "edit", "PUT", data);
            return true;            
        }

        public bool Eliminar(Pintura pintura)
        {            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Pintura));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, pintura);
            string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString(BASE_URL + "delete", "DELETE", data);
            return true;            
        }
    }
}