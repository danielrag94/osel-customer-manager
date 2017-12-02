using ServiciosOsel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosOsel.Servicios.Sesion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSesion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioSesion.svc o ServicioSesion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioSesion : IServicioSesion
    {
        osel_dbEntities BaseDatos = new osel_dbEntities();

        public string Desencriptar(string contrasena)
        {
            string result = string.Empty;
            byte[] decrypted = Convert.FromBase64String(contrasena);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            return result;
        }        

        public string Encriptar(string constrasena)
        {
            string result = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(constrasena);
            result = Convert.ToBase64String(encrypted);
            return result;
        }

        public bool Login(string email, string contrasena)
        {
            string p = Encriptar(contrasena);
            p = p + ",";
            bool correcto = false;
            Usuario user = new Usuario();
            var Query = from usuario in BaseDatos.Usuario
                        where usuario.Email == email
                        select usuario;
            foreach (var result in Query)
            {
                user = result;
            }
            p = Desencriptar(user.Contrasena);
            if (p.Equals(contrasena))
            {
                correcto = true;
            }
            else
            {
                correcto = false;
            }
            return correcto;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
