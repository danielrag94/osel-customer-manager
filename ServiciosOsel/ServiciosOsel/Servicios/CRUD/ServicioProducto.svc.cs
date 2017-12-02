using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosOsel.Entities;

namespace ServiciosOsel.Servicios.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioProducto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioProducto.svc o ServicioProducto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioProducto : IServicioProducto
    {
        osel_dbEntities BaseDatos = new osel_dbEntities();

        public bool Crear(Producto producto)
        {
            BaseDatos.Producto.Add(producto);
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Editar(Producto producto)
        {
            var product = BaseDatos.Producto.FirstOrDefault(x => x.Id == producto.Id);
            product.Codigo_Pintura = producto.Codigo_Pintura;
            product.Precio = producto.Precio;
            product.Calidad = producto.Calidad;
            product.Tamano = product.Tamano;
            product.Acabado = producto.Acabado;
            product.Tipo = producto.Tipo;
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Eliminar(Producto product)
        {
            Producto producto = BaseDatos.Producto.Find(product.Id);
            BaseDatos.Producto.Remove(producto);
            BaseDatos.SaveChanges();
            return true;            
        }

        public Producto LeerPorId(string id)
        {
            Producto product = new Producto();
            int ID = int.Parse(id);
            var Query = from producto in BaseDatos.Producto where producto.Id == ID select producto;
            foreach (var result in Query)
            {
                product = result;
            }
            return product;
        }

        public List<Producto> LeerTodos()
        {
            List<Producto> lista = new List<Producto>();
            var Query = from producto in BaseDatos.Producto select producto;
            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }
    }
}
