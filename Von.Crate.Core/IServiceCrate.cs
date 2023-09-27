using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Von.Crate.Core
{
    public interface IServiceCrate
    {
        public void AddService(IServiceCollection services);
    }
}
