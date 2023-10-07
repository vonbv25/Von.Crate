using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crate
{
    public interface IServiceCrate
    {
        public void AddService(IServiceCollection services);
    }
}
