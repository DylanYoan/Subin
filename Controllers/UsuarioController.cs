
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(new Usuario().GetUsuario());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Register()
        {
            return View(new Usuario());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection formcollection, Usuario usuarito)
        {
            try
            {
                usuarito.AddUsuario(usuarito);
                return View(usuarito);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View(usuarito);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            // Validar las credenciales del usuario...
            int usuarito = new Usuario().GetUsuarioForLogin(email, password);



            // Si las credenciales son válidas, guardar el id del usuario en la sesión
            Session["id_usuario"] = usuarito;

            // Redirigir a la página principal
            return RedirectToAction("Index", "Home");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Usuario().ObtenerUsuarioById(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Usuario usuarito)
        {
            try
            {
                usuarito.UpdateUsuario(usuarito);
                return View("Index", new Usuario().GetUsuario());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Usuario().ObtenerUsuarioById(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Usuario usuarito)
        {
            try
            {
                usuarito.DeletePersona(usuarito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
