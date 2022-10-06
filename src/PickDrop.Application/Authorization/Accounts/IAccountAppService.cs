using System.Threading.Tasks;
using Abp.Application.Services;
using PickDrop.Authorization.Accounts.Dto;

namespace PickDrop.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
