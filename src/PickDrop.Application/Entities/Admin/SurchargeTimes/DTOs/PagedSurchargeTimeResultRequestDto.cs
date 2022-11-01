using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Models.Categories;
using PickDrop.Models.SurchargeTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.SurchargeTimes.DTOs
{
    [AutoMapFrom(typeof(PagedSurchargeTimeModel)), AutoMapTo(typeof(PagedSurchargeTimeModel))]

    public class PagedSurchargeTimeResultRequestDto : PagedResultRequestDto
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public bool IsActive { get; set; }
    }
}
