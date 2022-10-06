using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PickDrop.Configuration.Dto;

namespace PickDrop.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PickDropAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
