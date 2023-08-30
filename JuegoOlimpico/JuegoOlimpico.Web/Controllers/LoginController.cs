using JuegoOlimpico.Web.Models;
using JuegoOlimpico.Web.proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JuegoOlimpico.Web.ClientEncrypt;

namespace JuegoOlimpico.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly UsuarioProxy usuarioProxy = new UsuarioProxy();



        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToString("dd MMMM yyyy").ToUpper();
            return View();
        }




        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel oModel, string returnUrl)
        {
            string error = string.Empty;
                        
            if (ModelState.IsValid)
            {
                try
                {
                    oModel.Nombre = AESEncrytDecry.DecryptStringAES(oModel.Nombre);
                    oModel.Contrasena = AESEncrytDecry.DecryptStringAES(oModel.Contrasena);


                    LimpiarSesiones();
                    FormsAuthentication.SignOut();

                    if (Session["UsuarioModel"] == null)
                    {
                        var respuesta = await usuarioProxy.ValidarCredenciales(oModel);

                        Session["UsuarioModel"] = respuesta;
                        Session["Token"] = respuesta.token;

                        return Json(new { success = true });
                    }
                       
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }

            ViewBag.Fecha = DateTime.Now.ToString("dd MMMM yyyy").ToUpper();
            
            return Json(new { success = false, Error = error });
        }


        public ActionResult RefreshToken()
        {
            return PartialView("_AntiForgeryToken");
        }

        public void LimpiarSesiones()
        {
            Session.Clear();
            Session.RemoveAll();
            Session["UsuarioModel"] = null;
           
        }

        public ActionResult CerrarSesion()
        {
            try
            {
                EliminarSesiones();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Login");
        }

        private void EliminarSesiones()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
        }

    }
}
