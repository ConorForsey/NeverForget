using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskTracker.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void ServiceInstaller(IServiceCollection services, IConfiguration confguration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(x => 
                                x.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                                { Title = "TaskTracker", Version = "V1" }));
        } 
    }
}
