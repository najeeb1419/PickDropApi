using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PickDrop.Entities.Admin.VehicleDetails;
using PickDrop.Models.VehicleDetails;
using PickDrop.Utitlities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PickDrop.Managers.VehicleDetails
{
    public class VehicleDetailManager : IVehicleDetailManager
    {

        private readonly IRepository<VehicleDetail> _vehicleDetailRepository;
        private readonly IMapper _mapper;

        public VehicleDetailManager(IRepository<VehicleDetail> vehicleDetailRepository, IMapper mapper)
        {
            _vehicleDetailRepository = vehicleDetailRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<VehicleDetailModel>> GetHistoryAsync(PagedVehicleDetailModel input)
        {
            var allHistory = _vehicleDetailRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Name.ToLower()))
                .WhereIf(!input.IsActive.IsNullOrWhiteSpace(), x => x.IsActive.ToString().ToLower().Contains(input.IsActive.ToLower()))
                .OrderByDescending(a => a.Id);
            var pagedallHistory = allHistory
                        .PageBy(input);
            var pagedAllHistory = await (from o in pagedallHistory
                                         select new VehicleDetailModel()
                                         {
                                             Id = o.Id,
                                             Name = o.Name,
                                             Description = o.Description,
                                             BaseFare = o.BaseFare,
                                             CategoryId = o.CategoryId,
                                             CostForKm = o.CostForKm,
                                             IsActive = o.IsActive,
                                             MinFareAmount = o.MinFareAmount,
                                             RentalAmountFor1Hour = o.RentalAmountFor1Hour,
                                             RentalCostForKM = o.RentalCostForKM,
                                             RentalKmLimitFor1Hour = o.RentalKmLimitFor1Hour,
                                             SurchargeTimes = o.SurchargeTimes,
                                             SurchargeTimeStatus = o.SurchargeTimeStatus,
                                             TenantId = o.TenantId,
                                             TimeFare = o.TimeFare,
                                         }).ToListAsync();

            var totalCount = await allHistory.CountAsync();

            return new PagedResultDto<VehicleDetailModel>(
                totalCount,
                pagedAllHistory
            );
        }

        public async Task<List<SelectItemDto>> GetVehicleDetailList()
        {
            var list = await _vehicleDetailRepository.GetAll().Select(x => new SelectItemDto()
            {
                Label = x.Name,
                Value = x.Id
            }).ToListAsync();
            return list;
        }

      


        public async Task<VehicleDetailModel> GetVehicleDetailAsync(int id)
        {
            return await _vehicleDetailRepository.GetAll().Where(o => o.Id == id).Select(o => new VehicleDetailModel()
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                BaseFare = o.BaseFare,
                CategoryId = o.CategoryId,
                CostForKm = o.CostForKm,
                IsActive = o.IsActive,
                MinFareAmount = o.MinFareAmount,
                RentalAmountFor1Hour = o.RentalAmountFor1Hour,
                RentalCostForKM = o.RentalCostForKM,
                RentalKmLimitFor1Hour = o.RentalKmLimitFor1Hour,
                SurchargeTimes = o.SurchargeTimes,
                SurchargeTimeStatus = o.SurchargeTimeStatus,
                TenantId = o.TenantId,
                TimeFare = o.TimeFare,
            }).FirstOrDefaultAsync();
        }

        




        public async Task<int> AddVehicleDetailAsync(VehicleDetailModel input)
        {
            var SubVehicleDetail = _mapper.Map<VehicleDetail>(input);
            return await _vehicleDetailRepository.InsertAndGetIdAsync(SubVehicleDetail);
        }

        public async Task<int> UpdateVehicleDetailAsync(VehicleDetailModel input)
        {
            var SubVehicleDetail = _mapper.Map<VehicleDetail>(input);
            return await _vehicleDetailRepository.InsertOrUpdateAndGetIdAsync(SubVehicleDetail);
        }

        public async Task DeleteVehicleDetailAsync(int id)
        {
            await _vehicleDetailRepository.DeleteAsync(id);
        }

    }
}
