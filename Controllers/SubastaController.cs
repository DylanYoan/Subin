
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubIn.Models;
using System.Web.Mvc;
using System.Web;
using System.Web.Helpers;

namespace SubIn.Controllers
{
    public class SubastaController : Controller
    {
        // GET: SubastaController
        public ActionResult Index()
        {
            //byte[] imageData = ObtenerImagenDesdeBD();
            //ViewBag.Imagen = imageData;

            return View(new Subasta().GetSubasta());
        }

        // GET: SubastaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubastaController/Create
        public ActionResult Create()
        {
            return View(new Subasta());
        }

        // POST: SubastaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formcollection, Subasta subastita)
        {
            HttpPostedFileBase FileBase = Request.Files[0];

            WebImage image = new WebImage(FileBase.InputStream);

            subastita.img_subasta = image.GetBytes();

            try
            {
                subastita.AddSubasta(subastita);
                return View(subastita);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(subastita);
            }
        }

        // GET: SubastaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Subasta().ObtenerSubastaById(id));
        }

        // POST: SubastaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Subasta subastita)
        {
            try
            {
                subastita.UpdateSubasta(subastita);
                return View("Index", new Subasta().GetSubasta());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: SubastaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Subasta().ObtenerSubastaById(id));
        }

        // POST: SubastaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Subasta subastita)
        {
            try
            {
                subastita.DeleteSubasta(subastita); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
