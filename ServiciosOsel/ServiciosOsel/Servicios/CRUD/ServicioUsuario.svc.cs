using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosOsel.Entities;

namespace ServiciosOsel.Servicios.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioUsuario.svc o ServicioUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioUsuario : IServicioUsuario
    {
        OselDBEntities BaseDatos = new OselDBEntities();

        public bool Crear(Usuario usuario)
        {
            BaseDatos.Usuario.Add(usuario);
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Editar(Usuario usuario)
        {
            var user = BaseDatos.Usuario.FirstOrDefault(x => x.Id == usuario.Id);
            user.Nombre = usuario.Nombre;
            user.Telefono = usuario.Telefono;
            user.Email = usuario.Email;
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Eliminar(Usuario user)
        {
            Usuario usuario = BaseDatos.Usuario.Find(user.Id);
            BaseDatos.Usuario.Remove(usuario);
            BaseDatos.SaveChanges();
            return true;
        }

        public Usuario LeerPorId(int id)
        {
            Usuario user = new Usuario();
            var Query = from usuario in BaseDatos.Usuario where usuario.Id == id select usuario;
            foreach (var result in Query)
            {
                user = result;
            }
            return user;
        }

        public List<Usuario> LeerPorNombre(string nombre)
        {
            List<Usuario> lista = new List<Usuario>();
            var Query = from usuario in BaseDatos.Usuario where usuario.Nombre == nombre select usuario;
            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }

        public List<Usuario> LeerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            var Query = from usuario in BaseDatos.Usuario select usuario;
            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }
    }
}
