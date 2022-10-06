using System.Threading.Tasks;
using PickDrop.Configuration.Dto;

namespace PickDrop.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
