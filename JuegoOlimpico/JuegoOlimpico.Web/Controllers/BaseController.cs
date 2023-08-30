using JuegoOlimpico.Web.ClientEncrypt;
using JuegoOlimpico.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JuegoOlimpico.Web.Controllers
{
    public class BaseController : Controller
    {
        //protected UsuarioModel userData;

        //public BaseController()
        //{
        //    userData = new UsuarioModel();
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            try
            {
              
            
               
                //Clave clave = new Clave();
                //string key = clave.generar(10000000, 99999999, 8);
                //string iv = clave.generar(10000000, 99999999, 8);
                ViewBag.__key = "-";
        
                //string URLSignOut = string.Empty;
                //if (userData == null)
                //{
                //    URLSignOut = "/Login/Index";
                //    Session.Abandon();
                //    FormsAuthentication.SignOut();

                //    filterContext.Result = new RedirectResult(URLSignOut);
                //    return;
                //}
               

              //  base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //public UsuarioModel UserData()
        //{
        //    UsuarioModel model = (UsuarioModel)Session["UsuarioModel"];
        //    if (model == null)
        //    {
        //        return model;
        //    }


        //    return model;
        //}

        public string RenderPartialViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext,
                    viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public Dictionary<string, object> GetErrorsFromModelState()
        {
            var errors = new Dictionary<string, object>();
            foreach (var key in ModelState.Keys)
            {
                // Only send the errors to the client.
                if (ModelState[key].Errors.Count > 0)
                {
                    errors[key] = ModelState[key].Errors;
                }
            }

            return errors;
        }

        public string ObtenerLoginUsuario()
        {

            return User.Identity.Name.Trim().ToUpper();
        }


    }
}