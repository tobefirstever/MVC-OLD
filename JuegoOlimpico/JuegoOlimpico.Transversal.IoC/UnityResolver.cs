using JuegoOlimpico.Application.Interfaces;
using JuegoOlimpico.Application.Main;
using JuegoOlimpico.Domain.Interfaces;
using JuegoOlimpico.Domain.Main;
using JuegoOlimpico.Infrastructure.Configuration;
using JuegoOlimpico.Infrastructure.Interfaces.Configuration;
using JuegoOlimpico.Infrastructure.Interfaces.Repository;
using JuegoOlimpico.Infrastructure.Repository.OracleRepository;

using JuegoOlimpico.Infrastructure.Repository.UnitOfWork;
using JuegoOlimpico.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace JuegoOlimpico.Transversal.IoC
{
    public sealed class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        public static IUnityContainer InitializeContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();

         

            container.RegisterType<IUsuarioApplication, UsuarioApplication>();
            container.RegisterType<IUsuarioDomain, UsuarioDomain>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();

            container.RegisterType<ILoginApplication, LoginApplication>();
            container.RegisterType<ILoginDomain, LoginDomain>();
            container.RegisterType<ILoginRepository, LoginRepository>();

            container.RegisterType<IPaisApplication, PaisApplication>();
            container.RegisterType<IPaisDomain, PaisDomain>();
            container.RegisterType<IPaisRepository, PaisRepository>();

            container.RegisterType<ISedeApplication, SedeApplication>();
            container.RegisterType<ISedeDomain, SedeDomain>();
            container.RegisterType<ISedeRepository, SedeRepository>();

            return container;
        }


        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}
