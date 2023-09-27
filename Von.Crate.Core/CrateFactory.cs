using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Von.Crate.Core
{
    public class CrateFactory : AbstractCrateFactory, ICrateFactory
    {
        public void UnpackService(IServiceCollection services)
        {
            serviceCrates.ForEach((crate) => 
            {
                try
                {
                    crate.AddService(services);
                }
                catch(Exception ex)
                {
                    throw new CrateException($"Error encountered in adding a service for {crate.GetType().FullName}", ex);
                }
            });
        }

        public void UnpackRouters(IEndpointRouteBuilder router)
        {
            routerCrates.ForEach((crate) =>
            {
                try
                {
                    crate.AddEndpoint(router);
                }
                catch (Exception ex)
                {
                    throw new CrateException($"Error encountered in adding a router for {crate.GetType().FullName}", ex);
                }
            });
        }

        public void LoadAllCrates()
        {
            LoadCrates();
        }

        protected override IServiceCrate CreateServiceCrate(Type serviceCrate)
        {
            return Activator.CreateInstance(serviceCrate) as IServiceCrate;
        }

        protected override IRouterCrate CreateRouterCrate(Type routerCrate)
        {
            return Activator.CreateInstance(routerCrate) as IRouterCrate;
        }
    }
}
