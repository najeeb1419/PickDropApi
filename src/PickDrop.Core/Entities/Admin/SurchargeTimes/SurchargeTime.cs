using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickDrop.Entities.Admin.VehicleDetails;

namespace PickDrop.Entities.Admin.SurchargeTimes
{
    public class SurchargeTime : FullAuditedEntity<int>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public  int VehicleDetailId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }

        public virtual VehicleDetail VehicleDetail { get; set; }
        
        public bool IsActive { get; set; }
    }
}
