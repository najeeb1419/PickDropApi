using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PickDrop.Authorization;

namespace PickDrop
{
    [DependsOn(
        typeof(PickDropCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PickDropApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PickDropAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PickDropApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
