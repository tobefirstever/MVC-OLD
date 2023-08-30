using JuegoOlimpico.Web.Models;
using JuegoOlimpico.Web.proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JuegoOlimpico.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioProxy usuarioProxy = new UsuarioProxy();

        // GET: Usuario
        public ActionResult Index()
        {

            return View();
        }


        public async Task<ActionResult> Buscar()
        {

            List<UsuarioListadoModel> usuarioListadoModels = new List<UsuarioListadoModel>();
            try
            {
                UsuarioBusquedaModel usuarioBusquedaModel = new UsuarioBusquedaModel();


                usuarioListadoModels = await usuarioProxy.Listar(usuarioBusquedaModel, Session["Token"].ToString());

                return Json(new { data = usuarioListadoModels }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "Ocurrió un problema al intentar acceder a la Web  - Usuario, intente nuevamente.",
                });
            }
        }


        public async Task<JsonResult> Obtener(int idpersona)
        {
            UsuarioListadoModel oPersona = new UsuarioListadoModel();

            try
            {
                oPersona = await usuarioProxy.Obtener(idpersona, Session["Token"].ToString());
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Ocurrió un problema al intentar acceder a la Web  - Usuario, intente nuevamente.",
                });
            }


            return Json(oPersona, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Guardar(UsuarioRegistroModel oPersona)
        {

            bool respuesta = true;
            try
            {

                if (oPersona.Id == 0)
                {
                    respuesta = await usuarioProxy.Insertar(oPersona, Session["Token"].ToString());
                }
                else
                {
                    respuesta = await usuarioProxy.Actualizar(oPersona, Session["Token"].ToString());

                }
            }
            catch
            {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> Eliminar(int id)
        {
            bool respuesta = true;
            try
            {

                respuesta = await usuarioProxy.Eliminar(id, Session["Token"].ToString());


            }
            catch
            {
                respuesta = false;
            }



            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}
