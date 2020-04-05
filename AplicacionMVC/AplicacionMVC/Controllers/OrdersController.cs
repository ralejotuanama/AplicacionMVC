using AplicacionMVC.Models;
using AplicacionMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionMVC.Controllers
{
    public class OrdersController : Controller
    {
        MVCContextType db = new MVCContextType();

        // GET: Orders
        public ActionResult NewOrder()
        {

            var orderView = new OrderView();

            orderView.Customer = new Customer();
            orderView.Products = new List<Product>();

            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0,  FirstName= "[seleccione un cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();

            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            var list = db.Customers.ToList();
              list.Add(new Customer { CustomerID = 0,  FirstName= "[seleccione un cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();
            
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            return View(orderView);
        }


        public ActionResult AddProduct(ProductOrder productOrder)
        {

            var list = db.Products.ToList();
              list.Add(new Product { ProductID = 0, Descripcion = "[seleccione un producto]" });
            list = list.OrderBy(c => c.Descripcion).ToList();

            ViewBag.ProductID = new SelectList(list, "ProductID", "Descripcion");

            return View(productOrder);
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection form)
        {

            var list = db.Products.ToList();
            //  list.Add(new Customer { CustomerID = 0,  = "[seleccione un tipo de documento]" });
            list = list.OrderBy(c => c.Descripcion).ToList();

            ViewBag.ProductID = new SelectList(list, "ProductID", "Descripcion");

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}