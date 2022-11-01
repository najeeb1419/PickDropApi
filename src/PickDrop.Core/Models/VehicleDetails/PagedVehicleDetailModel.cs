using Abp.Application.Services.Dto;
using PickDrop.Entities.Admin.SurchargeTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.VehicleDetails
{
    public class PagedVehicleDetailModel : PagedResultRequestDto
    {
        public virtual int TenantId { get; set; }
        public string Name { get; set; }
        public decimal CostForKm { get; set; }
        public decimal TimeFare { get; set; }
        public decimal BaseFare { get; set; }
        public decimal MinFareAmount { get; set; }
        public decimal RentalCostForKM { get; set; }
        public decimal RentalAmountFor1Hour { get; set; }
        public decimal RentalKmLimitFor1Hour { get; set; }
        public bool SurchargeTimeStatus { get; set; }
        public string IsActive { get; set; }
    }
}
