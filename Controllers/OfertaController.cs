
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class OfertaController : Controller
    {
        // GET: OfertaController
        public ActionResult Index()
        {
            return View(new Oferta().GetOferta());
        }

        // GET: OfertaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OfertaController/Create
        public ActionResult Create()
        {
            return View(new Oferta());
        }

        // POST: OfertaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Oferta ofertita)
        {
            try
            {
                ofertita.AddOferta(ofertita);
                return View(ofertita);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(ofertita);
            }
        }

        // GET: OfertaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Oferta().ObtenerOfertaById(id));
        }

        // POST: OfertaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Oferta ofertita)
        {
            try
            {
                ofertita.UpdateOferta(ofertita);
                return View("Index", new Oferta().GetOferta());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: OfertaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Oferta().ObtenerOfertaById(id));
        }

        // POST: OfertaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Oferta ofertita)
        {
            try
            {
                ofertita.DeleteOferta(ofertita); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
