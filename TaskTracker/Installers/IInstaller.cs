using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Installers
{
    public interface IInstaller
    {
        void ServiceInstaller(IServiceCollection services, IConfiguration confguration);
    }
}
