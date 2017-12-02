using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosOsel.Entities;

namespace ServiciosOsel.Servicios.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioOrden" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioOrden.svc o ServicioOrden.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioOrden : IServicioOrden
    {
        osel_dbEntities BaseDatos = new osel_dbEntities();

        public bool Crear(Orden orden)
        {
            BaseDatos.Orden.Add(orden);
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Editar(Orden orden)
        {
            var order = BaseDatos.Orden.FirstOrDefault(x => x.Id == orden.Id);
            order.Detalle = orden.Detalle;
            order.Fecha = orden.Fecha;
            order.Total = orden.Total;
            order.Id_Usuario = orden.Id_Usuario;
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Eliminar(Orden order)
        {
            Orden orden = BaseDatos.Orden.Find(order.Id);
            BaseDatos.Orden.Remove(orden);
            BaseDatos.SaveChanges();
            return true;
        }

        public Orden LeerPorFecha(string fecha)
        {
            DateTime Fecha = DateTime.Parse(fecha);
            Orden order = new Orden();
            var Query = from orden in BaseDatos.Orden where orden.Fecha == Fecha select orden;
            foreach (var result in Query)
            {
                order = result;
            }
            return order;
        }

        public Orden LeerPorId(string id)
        {
            Orden order = new Orden();
            int ID = int.Parse(id);
            var Query = from orden in BaseDatos.Orden where orden.Id == ID select orden;
            foreach (var result in Query)
            {
                order = result;
            }
            return order;
        }

        public List<Orden> LeerTodos()
        {
            List<Orden> lista = new List<Orden>();
            var Query = from orden in BaseDatos.Orden select orden;
            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }
    }
}
