using JuegoOlimpico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JuegoOlimpico.Services.WebApi.Controllers
{
    public class PaisController : BaseApiController
    {

        private readonly IPaisApplication _paisApplication;

        public PaisController(IPaisApplication paisApplication)
        {
            _paisApplication = paisApplication;
        }

        [HttpGet()]
        [Route("api/pais")]
        public async Task<IHttpActionResult> Listar()
        {
            return Ok(await _paisApplication.Listar());
        }

    }
}