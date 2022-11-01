using Abp.Application.Services;
using PickDrop.Entites.Admin.Categories.DTOs;
using PickDrop.Entities.Admin.Categories.DTOs;
using PickDrop.Entities.Admin.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickDrop.Entities.Admin.VehicleDetails.DTOs;
using Abp.Domain.Repositories;
using PickDrop.Managers.Categories;
using PickDrop.Managers.VehicleDetails;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickDrop.Models.Categories;
using PickDrop.Utitlities;
using PickDrop.Models.VehicleDetails;

namespace PickDrop.Entities.Admin.VehicleDetails
{
    public class VehicleDetailAppService : AsyncCrudAppService<VehicleDetail, VehicleDetailDto, int, PagedVehicleDetailResultRequestDto>, IVehicleDetailAppService
    {
        private readonly IVehicleDetailManager _vehicleDetailManager;
        public VehicleDetailAppService(IVehicleDetailManager vehicleDetailManager , IRepository<VehicleDetail, int> repository) : base(repository)
        {
            _vehicleDetailManager = vehicleDetailManager;
        }


        public async Task<PagedResultDto<VehicleDetailDto>> GetHistory(PagedVehicleDetailResultRequestDto input)
        {
            var data = await _vehicleDetailManager.GetHistoryAsync(ObjectMapper.Map<PagedVehicleDetailModel>(input));
            var finalResult = new PagedResultDto<VehicleDetailDto>();
            finalResult.Items = ObjectMapper.Map<List<VehicleDetailDto>>(data.Items);
            finalResult.TotalCount = data.TotalCount;
            return finalResult;
        }


       
        


       

        public async Task<List<SelectItemDto>> GetVehicleDetailList()
        {
            var list = await _vehicleDetailManager.GetVehicleDetailList();
            return list;
        }




        public async Task<VehicleDetailDto> GetVehicleDetailAsync(int id)
        {
            var data = await _vehicleDetailManager.GetVehicleDetailAsync(id);
            return ObjectMapper.Map<VehicleDetailDto>(data);
        }

        public async Task<int> AddVehicleDetailAsync(VehicleDetailDto input)
        {
            var data = ObjectMapper.Map<VehicleDetailModel>(input);
            return await _vehicleDetailManager.AddVehicleDetailAsync(data);
        }

        public async Task<int> UpdateProuductSubVehicleDetailAsync(VehicleDetailDto input)
        {
            var data = ObjectMapper.Map<VehicleDetailModel>(input);
            return await _vehicleDetailManager.UpdateVehicleDetailAsync(data);
        }

        public async Task DeleteProuductSubVehicleDetailAsync(int id)
        {
            await _vehicleDetailManager.DeleteVehicleDetailAsync(id);
        }

    }
}
