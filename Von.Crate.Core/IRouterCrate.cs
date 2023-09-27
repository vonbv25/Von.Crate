using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Von.Crate.Core
{
    public interface IRouterCrate
    {
        void AddEndpoint(IEndpointRouteBuilder app);
    }
}
