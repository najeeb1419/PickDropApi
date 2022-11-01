using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickDrop.Entities.Admin.Categories;
using PickDrop.Entities.Admin.SurchargeTimes;

namespace PickDrop.Entities.Admin.VehicleDetails
{
    public class VehicleDetail : FullAuditedEntity<int>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
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
