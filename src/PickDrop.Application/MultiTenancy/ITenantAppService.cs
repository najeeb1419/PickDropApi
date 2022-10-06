using Abp.Application.Services;
using PickDrop.MultiTenancy.Dto;

namespace PickDrop.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

