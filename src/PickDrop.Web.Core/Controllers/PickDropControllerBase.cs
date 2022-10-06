using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace PickDrop.Controllers
{
    public abstract class PickDropControllerBase: AbpController
    {
        protected PickDropControllerBase()
        {
            LocalizationSourceName = PickDropConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
