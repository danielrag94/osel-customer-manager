using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosOsel.Entities;

namespace ServiciosOsel.Servicios.CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPintura" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioPintura.svc o ServicioPintura.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioPintura : IServicioPintura
    {
        OselDBEntities BaseDatos = new OselDBEntities();

        public bool Crear(Pintura pintura)
        {
            BaseDatos.Pintura.Add(pintura);
            BaseDatos.SaveChanges();
            return true;            
        }

        public bool Editar(Pintura pintura)
        {
            var paint = BaseDatos.Pintura.FirstOrDefault(x => x.Id == pintura.Id);
            paint.Codigo = pintura.Codigo;
            paint.Nombre = pintura.Nombre;
            BaseDatos.SaveChanges();
            return true;
        }

        public bool Eliminar(Pintura paint)
        {
            Pintura pintura = BaseDatos.Pintura.Find(paint.Id);
            BaseDatos.Pintura.Remove(pintura);
            BaseDatos.SaveChanges();
            return true;
        }

        public Pintura LeerPorCodigo(string codigo)
        {
            Pintura paint = new Pintura();
            var Query = from pintura in BaseDatos.Pintura where pintura.Codigo == codigo select pintura;
            foreach (var result in Query)
            {
                paint = result;
            }
            return paint;
        }

        public Pintura LeerPorId(int id)
        {            
            Pintura paint = new Pintura();
            var Query = from pintura in BaseDatos.Pintura where pintura.Id == id select pintura;
            foreach (var result in Query)
            {
                paint = result;
            }
            return paint;            
        }

        public List<Pintura> LeerTodos()
        {
            List<Pintura> lista = new List<Pintura>();
            var Query = from pintura in BaseDatos.Pintura select pintura;
            foreach (var result in Query)
            {
                lista.Add(result);
            }
            Console.WriteLine("Resultado " + lista.First());
            return lista;
        }
    }
}
