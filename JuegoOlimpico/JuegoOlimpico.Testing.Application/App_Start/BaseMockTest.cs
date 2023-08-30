using System.IO;
using System.Security.Principal;
using System.Web;
using JuegoOlimpico.Transversal.Mapper;

namespace JuegoOlimpico.Testing.Application.App_Start
{
    public class BaseMockTest
    {
        protected static void Register()
        {
            Mapping.Inicializate();
            AsignarMockContext();
        }

        protected static void AsignarMockContext()
        {
            var request = new HttpRequest("", "http://my.url.com", "");
            var response = new HttpResponse(new StringWriter());
            var context = new HttpContext(request, response);

            context.User = new GenericPrincipal(new GenericIdentity("username"), new string[0]);

            HttpContext.Current = context;
        }
    }
}
