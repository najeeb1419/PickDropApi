using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Entities.Admin.Categories;
using PickDrop.Entities.Admin.SurchargeTimes;
using PickDrop.Entities.Admin.VehicleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.VehicleDetails
{
    [AutoMapFrom(typeof(VehicleDetail)), AutoMapTo(typeof(VehicleDetail))]
    public class VehicleDetailModel : EntityDto<int>
    {
        public virtual int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal CostForKm { get; set; }
        public decimal TimeFare { get; set; }
        public decimal BaseFare { get; set; }
        public decimal MinFareAmount { get; set; }
        public decimal RentalCostForKM { get; set; }
        public decimal RentalAmountFor1Hour { get; set; }
        public decimal RentalKmLimitFor1Hour { get; set; }
        public bool SurchargeTimeStatus { get; set; }
        public virtual ICollection<SurchargeTime> SurchargeTimes { get; set; }
        public bool IsActive { get; set; }
    }
}
