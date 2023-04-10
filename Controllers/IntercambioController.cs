using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubIn.Models;
using System.Web.Mvc;
using System.Web;

namespace SubIn.Controllers
{
    public class IntercambioController : Controller
    {
        // GET: IntercambioController
        public ActionResult Index(int id)
        {
            HttpCookie cookie = new HttpCookie("id", id.ToString());
            Response.Cookies.Add(cookie);
            return View(new Item().GetInventario(id));
        }

        // GET: IntercambioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IntercambioController/Create
        public ActionResult Create()
        {
            return View(new Intercambio());
        }

        // POST: IntercambioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Intercambio intercambiocito)
        {
            try
            {
                HttpCookie IdItem2Cookie = new HttpCookie("id_item2", intercambiocito.id_item2.ToString());
                HttpCookie IdUsuarioCookie = new HttpCookie("id_item2", intercambiocito.id_usuario.ToString());
                
                
                Response.Cookies.Add(IdItem2Cookie);
                Response.Cookies.Add(IdUsuarioCookie);

                intercambiocito.AddIntercambio(intercambiocito);
                return View(intercambiocito);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(intercambiocito);
            }
        }

        // GET: IntercambioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Intercambio().ObtenerIntercambioById(id));
        }

        // POST: IntercambioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Intercambio intercambiocito)
        {
            try
            {
                intercambiocito.UpdateIntercambio(intercambiocito);
                return View("Index", new Intercambio().GetIntercambio());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: IntercambioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Intercambio().ObtenerIntercambioById(id));
        }

        // POST: IntercambioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Intercambio intercambiocito)
        {
            try
            {
                intercambiocito.DeleteIntercambio(intercambiocito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
