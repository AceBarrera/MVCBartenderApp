using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View(new DbContext().Orders);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Order order = new DbContext().Orders.Create();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DbContext context = new DbContext();
                Order order = context.Orders.Find(id);
                context.Orders.Remove(order);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Order/Complete/5
        [HttpPost]
        public ActionResult Complete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add complete logic here
                DbContext context = new DbContext();
                Order order = context.Orders.Find(id);
                order.Complete = true;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
