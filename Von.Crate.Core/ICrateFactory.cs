using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Von.Crate.Core
{
    public interface ICrateFactory
    {
        void LoadAllCrates();
        void UnpackService(IServiceCollection services);
        void UnpackRouters(IEndpointRouteBuilder router);
    }
}
