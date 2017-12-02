using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClienteWebOsel.Models
{
    public class Usuario
    {
        [Display(Name = "Id")]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Nombre")]
        public string Nombre
        {
            get;
            set;
        }

        [Display(Name = "Telefono")]
        public string Telefono
        {
            get;
            set;
        }

        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }

        [Display(Name = "Contrasena")]
        public string Contrasena
        {
            get;
            set;
        }

        [Display(Name = "Nivel")]
        public string Nivel
        {
            get;
            set;
        }
    }
}