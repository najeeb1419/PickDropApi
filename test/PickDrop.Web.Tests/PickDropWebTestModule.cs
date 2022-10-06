using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PickDrop.EntityFrameworkCore;
using PickDrop.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace PickDrop.Web.Tests
{
    [DependsOn(
        typeof(PickDropWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PickDropWebTestModule : AbpModule
    {
        public PickDropWebTestModule(PickDropEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PickDropWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PickDropWebMvcModule).Assembly);
        }
    }
}