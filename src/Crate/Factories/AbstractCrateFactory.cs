using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Crate.Factories
{
    public abstract class AbstractCrateFactory
    {
        protected List<IRouterCrate> routerCrates = new List<IRouterCrate>();
        protected List<IServiceCrate> serviceCrates = new List<IServiceCrate>();

        protected abstract IServiceCrate CreateServiceCrate(Type serviceCrate);
        protected abstract IRouterCrate CreateRouterCrate(Type routerCrate);
        public void LoadCrates(string currentDomainPath = "")
        {
            var directoryPath = currentDomainPath;

            if (string.IsNullOrWhiteSpace(currentDomainPath)) directoryPath = AppDomain.CurrentDomain.BaseDirectory;

            foreach (var dllFile in Directory.GetFiles(directoryPath, "*.dll"))
            {
                var loadedAssembly = Assembly.LoadFrom(dllFile);

                if (loadedAssembly == null) throw new CrateException($"Unable to load this assembly file{dllFile}");

                var crateTypes = loadedAssembly.GetTypes().Where(type => typeof(IRouterCrate).IsAssignableFrom(type) && !type.IsInterface || typeof(IServiceCrate).IsAssignableFrom(type) && !type.IsInterface);

                foreach (var crateType in crateTypes)
                {
                    try
                    {
                        if (crateType.GetInterface(typeof(IServiceCrate).FullName) != null)
                        {
                            var serviceCrate = CreateServiceCrate(crateType);
                            if (serviceCrate != null) serviceCrates.Add(serviceCrate);
                        }
                        if (crateType.GetInterface(typeof(IRouterCrate).FullName) != null)
                        {
                            var routerCrate = CreateRouterCrate(crateType);
                            if (routerCrate != null) routerCrates.Add(routerCrate);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new CrateException($"Unable to initialize: {crateType.FullName}.", e);
                    }
                }
            }
        }

    }
}
