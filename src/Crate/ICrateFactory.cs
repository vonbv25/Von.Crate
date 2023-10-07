using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Crate
{
    public interface ICrateFactory
    {
        void LoadAllCrates();
        void UnpackService(IServiceCollection services);
        void UnpackRouters(IEndpointRouteBuilder router);
    }
}
