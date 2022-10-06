using System.Threading.Tasks;
using Abp.Application.Services;
using PickDrop.Sessions.Dto;

namespace PickDrop.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
