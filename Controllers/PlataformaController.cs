
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class PlataformaController : Controller
    {
        // GET: PlataformaController
        public ActionResult Index()
        {
            return View(new Plataforma().GetPlataforma());
        }

        // GET: PlataformaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlataformaController/Create
        public ActionResult Create()
        {
            return View(new Plataforma());
        }

        // POST: PlataformaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Plataforma plataformita)
        {
            try
            {
                plataformita.AddPlataforma(plataformita);
                return View(plataformita);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(plataformita);
            }
        }

        // GET: PlataformaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Plataforma().ObtenerPlataformaById(id));
        }

        // POST: PlataformaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Plataforma plataformita)
        {
            try
            {
                plataformita.UpdatePlataforma(plataformita);
                return View("Index", new Plataforma().GetPlataforma());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: PlataformaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Plataforma().ObtenerPlataformaById(id));
        }

        // POST: PlataformaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Plataforma plataformita)
        {
            try
            {
                plataformita.DeletePlataforma(plataformita); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
