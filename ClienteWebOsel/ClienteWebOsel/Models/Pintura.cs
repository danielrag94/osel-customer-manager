using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClienteWebOsel.Models
{
    public class Pintura
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

        [Display(Name = "Codigo")]
        public string Codigo
        {
            get;
            set;
        }

        [Display(Name = "Color")]
        public string Color
        {
            get;
            set;
        }
    }
}