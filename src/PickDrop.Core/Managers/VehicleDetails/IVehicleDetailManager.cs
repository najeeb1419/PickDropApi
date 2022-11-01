using Abp.Application.Services.Dto;
using Abp.Dependency;
using PickDrop.Models.VehicleDetails;
using PickDrop.Utitlities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickDrop.Managers.VehicleDetails
{
    public interface IVehicleDetailManager : ITransientDependency
    {
        Task<PagedResultDto<VehicleDetailModel>> GetHistoryAsync(PagedVehicleDetailModel input);
        Task<List<SelectItemDto>> GetVehicleDetailList();
        Task<VehicleDetailModel> GetVehicleDetailAsync(int id);
        Task<int> AddVehicleDetailAsync(VehicleDetailModel input);
        Task<int> UpdateVehicleDetailAsync(VehicleDetailModel input);
        Task DeleteVehicleDetailAsync(int id);
    }
}