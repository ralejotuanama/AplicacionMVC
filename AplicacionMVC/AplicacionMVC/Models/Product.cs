﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionMVC.Models
{
    public class Product
    {

   [Key]
        public int ProductID { get; set; }

        public string Descripcion { get; set; }

        public DateTime LastBuy { get; set; }


        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}