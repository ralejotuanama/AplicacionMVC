using AplicacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionMVC.ViewModels
{
    public class OrderView
    {

        public Customer Customer { get; set; }

        public ProductOrder ProductOrder { get; set; }
        public List<ProductOrder> Products { get; set; }
    }
}