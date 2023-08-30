using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using JuegoOlimpico.Transversal.Common;

namespace JuegoOlimpico.Services.WebApi.Core
{
    public class DynamicPolicyProviderFactory : ICorsPolicyProviderFactory
    {
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequested = corsRequestContext.Origin;
            var policy = GetPolicyForControllerAndOrigin(originRequested);
            return new CustomPolicyProvider(policy);
        }
        private CorsPolicy GetPolicyForControllerAndOrigin(string originRequested)
        {
            var origins = ConfigurationManager.AppSettings[Constantes.OriginKey];
            if(origins.Split(Constantes.Coma).Any(p=> p == originRequested))
            {
                var policy = new CorsPolicy();
                policy.Origins.Add(originRequested);
                policy.AllowAnyHeader = true;
                policy.AllowAnyMethod = true;
                return policy;
            }
            return null;
        }
    }
}