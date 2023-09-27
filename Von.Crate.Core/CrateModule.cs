using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Von.Crate.Core
{
    public static class CrateModule
    {
        private static ICrateFactory factory;
        static CrateModule()
        {
            factory = new CrateFactory();
            factory.LoadAllCrates();
        }

        public static void AddCrate(this IServiceCollection services) 
        {
            factory.UnpackService(services);
        }

        public static void MapCrate(this IEndpointRouteBuilder router)
        {
            factory.UnpackRouters(router);
        }

    }
}
