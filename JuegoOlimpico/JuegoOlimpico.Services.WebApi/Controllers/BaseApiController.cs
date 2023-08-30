using System.Web.Http;

namespace JuegoOlimpico.Services.WebApi.Controllers
{
    /// <summary>
    /// BaseApiController
    /// </summary>
    [Authorize]
    public class BaseApiController : ApiController
    {
    }
}