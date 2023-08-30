using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace JuegoOlimpico.Services.WebApi.Core
{
    /// <summary>
    /// CustomPolicyProvider
    /// </summary>
    public class CustomPolicyProvider : ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;
        public CustomPolicyProvider(CorsPolicy policy)
        {
            _policy = policy;
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}