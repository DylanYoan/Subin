
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubIn.Models;
using System.Web.Mvc;

namespace SubIn.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View(new Categoria().GetCategoria());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View(new Categoria());
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Categoria categoriacita)
        {
            try
            {
                categoriacita.AddCategoria(categoriacita);
                return View(categoriacita);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(categoriacita);
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Categoria().ObtenerCategoriaById(id));
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Categoria categoriacita)
        {
            try
            {
                categoriacita.UpdateCategoria(categoriacita);
                return View("Index", new Categoria().GetCategoria());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Categoria().ObtenerCategoriaById(id));
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Categoria categoriacito)
        {
            try
            {
                categoriacito.DeleteCategoria(categoriacito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
