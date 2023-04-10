
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class PerteneceController : Controller
    {
        // GET: PerteneceController
        public ActionResult Index()
        {
            return View(new Pertenece().GetPertenece());
        }

        // GET: PerteneceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerteneceController/Create
        public ActionResult Create()
        {
            return View(new Pertenece());
        }

        // POST: PerteneceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Pertenece pertenecito)
        {
            try
            {
                pertenecito.AddPertenece(pertenecito);
                return View(pertenecito);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(pertenecito);
            }
        }

        // GET: PerteneceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Pertenece().ObtenerPerteneceById(id));
        }

        // POST: PerteneceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Pertenece pertenecito)
        {
            try
            {
                pertenecito.UpdatePertenece(pertenecito);
                return View("Index", new Pertenece().GetPertenece());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: PerteneceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Pertenece().ObtenerPerteneceById(id));
        }

        // POST: PerteneceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Pertenece pertenecito)
        {
            try
            {
                pertenecito.DeletePertenece(pertenecito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
