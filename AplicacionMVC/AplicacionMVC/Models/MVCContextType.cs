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

        public DbSet<DocumentType> DocumentTypes { get; set; }


        public DbSet<Employe> Employes { get; set; }

        public System.Data.Entity.DbSet<AplicacionMVC.Models.Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}