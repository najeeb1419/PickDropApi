using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.SurchargeTimes
{
    public class SurchargeTimeModel : EntityDto<int>
    {
        public virtual int TenantId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int VehicleDetailId { get; set; }
        public bool IsActive { get; set; }
    }
}
