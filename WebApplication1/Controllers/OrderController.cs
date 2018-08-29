using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using AppContext = WebApplication1.Models.AppContext;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var Orders = new AppContext().Orders.Include("MenuItem").Where(o => !o.Complete);
            ViewBag.Orders = Orders.ToList();
            ViewBag.Count = Orders.Count();
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            AppContext context = new AppContext();
            if (context.MenuItems.Count() == 0){
                context.MenuItems.Add(new MenuItem() { Name = "Purple Nurple" });
                context.MenuItems.Add(new MenuItem() { Name = "Ghermann's Special" });
                context.MenuItems.Add(new MenuItem() { Name = "ITS BLüDDDD" });
                context.MenuItems.Add(new MenuItem() { Name = "The Cleric Beast" });
                context.MenuItems.Add(new MenuItem() { Name = "Bloody Mary" });
                context.SaveChanges();
            }
            ViewBag.MenuItems = context.MenuItems;
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            // TODO: Add insert logic here
            AppContext context = new AppContext();
            MenuItem menuItem = context.MenuItems.Find(int.Parse(collection.Get("MenuItem")));
            Order order = context.Orders.Add(new Order() { MenuItem = menuItem });
            context.SaveChanges();
            return Create();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                AppContext context = new AppContext();
                Order order = context.Orders.Find(id);
                context.Orders.Remove(order);
                context.SaveChanges();
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
                AppContext context = new AppContext();
                Order order = context.Orders.Find(id);
                order.Complete = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
