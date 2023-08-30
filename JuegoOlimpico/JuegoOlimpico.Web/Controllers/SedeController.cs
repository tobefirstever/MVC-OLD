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
    public class SedeController : BaseController
    {

        private readonly SedeProxy sedeProxy = new SedeProxy();

        public async Task<ActionResult> Index()
        {
            SedeOlimpicaModel sedeOlimpicaModel = new SedeOlimpicaModel();
            sedeOlimpicaModel.Paises  =  await sedeProxy.ListarPais(Session["Token"].ToString());


            return View(sedeOlimpicaModel);
        }

        public async Task<ActionResult> Buscar(string sidx, string sord, int page, int rows, int? idPais)
        {

            List<SedeModel> sedeModels = new List<SedeModel>();
            try
            {

                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;
                int totalRecords = 0;

                sedeModels = await sedeProxy.ListarSede(Session["Token"].ToString());

                if(idPais != 0)
                {
                    sedeModels = sedeModels.Where(x => x.IdPais == idPais).ToList();
                }


                totalRecords = (sedeModels.Count > 0) ? sedeModels.Count() : 0;

                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = sedeModels
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
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

        public async Task< ActionResult> ObtenerSede(SedeModel sedeModel)
        {
            RegistrarSedeModel registrarSede = new RegistrarSedeModel();

            try
            {
                registrarSede.Paises = await sedeProxy.ListarPais(Session["Token"].ToString());

                if (sedeModel.IdSede != 0)
                {
                    var obtenerSede = await sedeProxy.ObtenerSede(sedeModel.IdSede, Session["Token"].ToString());

                    registrarSede.IdPais = obtenerSede.IdPais;
                    registrarSede.IdSede = obtenerSede.IdSede;
                    registrarSede.NombrePais = obtenerSede.NombrePais;
                    registrarSede.NombreSede = obtenerSede.NombreSede;
                    registrarSede.NroComplejos = obtenerSede.NroComplejos;
                    registrarSede.Presupuesto = obtenerSede.Presupuesto;

                }
               
                return Json(new
                {
                    PartialConfiguracion = RenderPartialViewToString("_Registro", registrarSede)
                });
            }
            catch(Exception ex)
            {
                  return Json(new
                {
                    success = false,
                    message = "Ocurrió un problema al intentar acceder a la Web  - Usuario, intente nuevamente.",
                });
            }

           
        }


        [HttpPost]
  
        public async Task<ActionResult> Eliminar(EliminarSedeModel eliminarSedeModel)
        {
            bool isValid = ModelState.IsValid;
            string strMensaje = string.Empty;
            if (isValid)
            {
                
                try
                {
                    bool bolResultado =await sedeProxy.Eliminar(eliminarSedeModel.IdSede, Session["Token"].ToString());

                    if (bolResultado)
                    {
                        strMensaje = "Se realizó el proceso satisfactoriamente…!";
                    }
                    else
                    {
                        strMensaje = "Error Inesperado, contacte al administrador de sistemas";
                    }
                }
                catch (Exception ex)
                {
                    strMensaje = ex.Message;
                    isValid = false;
                }
            }
            return Json(new
            {
                Valid = isValid,
                Mensaje = strMensaje,
                GetErrorsFromModelState = GetErrorsFromModelState(),
                Resultado = ""
            });
        }

        [HttpPost]

        public async Task<ActionResult> Grabar(RegistrarSedeModel registrarSedeModel)
        {
            bool isValid = ModelState.IsValid;
            bool resultado = false;
            string mensaje = string.Empty;

            string token = Session["Token"].ToString();


            if (isValid)
            {
              
                try
                {
                    if (registrarSedeModel.IdSede == 0)
                    {

                        resultado =  await sedeProxy.Insertar(registrarSedeModel, token);

                        
                        if (resultado)
                        {
                           
                            mensaje = "Se realizó el proceso satisfactoriamente…!";
                        }
                        else
                        {
                            resultado = false;
                            mensaje = "Error Inesperado, contacte al administrador de sistemas";
                        }
                    }
                    else
                    {
                       
                        resultado = await sedeProxy.Actualizar(registrarSedeModel,token);
                        if (resultado)
                        {
                            mensaje = "Se realizó el proceso satisfactoriamente…!";
                        }
                        else
                        {
                            mensaje = "Error Inesperado, contacte al administrador de sistemas";
                        }
                    }
                }
                catch (Exception ex)
                {

                    mensaje = ex.Message;
                    isValid = false;
                }
            }
            return Json(new
            {
                Valid = isValid,
                Valid2 = resultado,
                Mensaje = mensaje,
                Errors = GetErrorsFromModelState()

            });
        }
    }
}
