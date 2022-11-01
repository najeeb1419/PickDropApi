using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Entities.Admin.VehicleDetails;
using PickDrop.Entities.Admin.VehicleDetails.DTOs;
using PickDrop.Models.SurchargeTimes;
using PickDrop.Models.VehicleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.SurchargeTimes.DTOs
{
    [AutoMapFrom(typeof(SurchargeTimeModel)), AutoMapTo(typeof(SurchargeTimeModel))]

    public class SurchargeTimeDto  : EntityDto<int>
    {
        public virtual int TenantId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int VehicleDetailId { get; set; }

        public bool IsActive { get; set; }
    }
}
