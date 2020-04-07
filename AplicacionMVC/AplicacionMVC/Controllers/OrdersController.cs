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
            orderView.Products = new List<ProductOrder>();

            Session["orderView"] = orderView;

            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0,  FirstName= "[seleccione un cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {

            orderView = Session["orderView"] as OrderView;

            var customerID = int.Parse(Request["CustomerID"]);


            if (customerID == 0)
            {

                var listC = db.Customers.ToList();
                listC.Add(new Customer { CustomerID = 0, FirstName = "[seleccione un cliente]" });
                listC = listC.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(listC, "CustomerID", "FullName");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(orderView);
            }

            var custom = db.Customers.Find(customerID);

            if (custom == null)
            {
                var list2 = db.Customers.ToList();
                list2.Add(new Customer { CustomerID = 0, FirstName = "[seleccione un cliente]" });
                list2 = list2.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(list2, "CustomerID", "FullName");
                ViewBag.Error = "no existe cliente";
                return View(orderView);
            } 


            if(orderView.Products.Count == 0)
            {
                var list = db.Customers.ToList();
                list.Add(new Customer { CustomerID = 0, FirstName = "[seleccione un cliente]" });
                list = list.OrderBy(c => c.FullName).ToList();

                ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
                ViewBag.Error = "debe ingresar detalle";
                return View(orderView);
            }


            var order = new Order
            {
                CustomerID = customerID,
                DateOrder = DateTime.Now,
                OrderStatus = OrderStatus.Created
            };

            db.Orders.Add(order);

            db.SaveChanges();

            var orderID = db.Orders.ToList().Select(o => o.OrderID).Max();

            foreach(var item in orderView.Products)
            {

                var orderDetail = new OrderDetail
                {
                    ProductID = item.ProductID,
                    Description = item.Descripcion,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderID = orderID
                };

                db.OrderDetails.Add(orderDetail);
            }

            db.SaveChanges();

            ViewBag.Message = string.Format("la orden {0} ok", orderID);

            var list3 = db.Customers.ToList();
            list3.Add(new Customer { CustomerID = 0, FirstName = "[seleccione un cliente]" });
            list3 = list3.OrderBy(c => c.FullName).ToList();

            ViewBag.CustomerID = new SelectList(list3, "CustomerID", "FullName");



             orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();

            Session["orderView"] = orderView;

            return View(orderView);

        }


        public ActionResult AddProduct()
        {

            var list = db.Products.ToList();
            list.Add(new Product { ProductID = 0, Descripcion = "[seleccione un producto]" });
            list = list.OrderBy(c => c.Descripcion).ToList();

            ViewBag.ProductID = new SelectList(list, "ProductID", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {

            var orderView = Session["orderView"] as OrderView;


            var productID = int.Parse(Request["ProductID"]);

            if(productID == 0)
            {

                var list = db.Products.ToList();
                list.Add(new Product { ProductID = 0,  Descripcion= "[seleccione un producto]" });
                list = list.OrderBy(c => c.Descripcion).ToList();
                ViewBag.ProductID = new SelectList(list, "ProductID", "Descripcion");
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }

            var prod = db.Products.Find(productID);

            if(prod == null)
            {
                var list = db.Products.ToList();
                list.Add(new Product { ProductID = 0, Descripcion = "[seleccione un producto]" });
                list = list.OrderBy(c => c.Descripcion).ToList();
                ViewBag.ProductID = new SelectList(list, "ProductID", "Descripcion");
                ViewBag.Error = "no existe producto";
                return View(productOrder);
            }

            productOrder = orderView.Products.Find(p => p.ProductID == productID);

            if(productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Descripcion = prod.Descripcion,
                    Price = prod.Price,
                    ProductID = prod.ProductID,
                    Quantity = float.Parse(Request["Quantity"])
                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }
           
            var listC = db.Customers.ToList();
            listC.Add(new Customer { CustomerID = 0, FirstName = "[seleccione un cliente]" });
            listC = listC.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(listC, "CustomerID", "FullName");

            return View("NewOrder", orderView);
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