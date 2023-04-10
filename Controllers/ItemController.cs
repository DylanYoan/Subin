
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class ItemController : Controller
    {
        // GET: ItemController
        public ActionResult Index()
        {
            return View(new Item().GetItem());
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View(new Item());
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Item itemcito)
        {
            try
            {
                itemcito.AddItem(itemcito);
                return View(itemcito);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(itemcito);
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Item().ObtenerItemById(id));
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Item itemcito)
        {
            try
            {
                itemcito.UpdateItem(itemcito);
                return View("Index", new Item().GetItem());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Item().ObtenerItemById(id));
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Item itemcito)
        {
            try
            {
                itemcito.DeleteItem(itemcito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
