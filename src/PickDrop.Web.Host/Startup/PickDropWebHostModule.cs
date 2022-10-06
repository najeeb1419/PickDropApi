using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PickDrop.Configuration;

namespace PickDrop.Web.Host.Startup
{
    [DependsOn(
       typeof(PickDropWebCoreModule))]
    public class PickDropWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PickDropWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PickDropWebHostModule).GetAssembly());
        }
    }
}
