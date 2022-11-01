using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Models.SurchargeTimes;
using PickDrop.Models.VehicleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.VehicleDetails.DTOs
{
    [AutoMapFrom(typeof(PagedVehicleDetailModel)), AutoMapTo(typeof(PagedVehicleDetailModel))]

    public class PagedVehicleDetailResultRequestDto : PagedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}
