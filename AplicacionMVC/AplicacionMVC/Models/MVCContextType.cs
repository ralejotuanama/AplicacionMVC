using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacionMVC.Models
{
    public class MVCContextType:DbContext
    {

        public MVCContextType():base("conexionmvc")
        {

        }


        public DbSet<Product> Products { get; set; }

    }
}