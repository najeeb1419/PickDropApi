using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.SurchargeTimes
{
    public class PagedSurchargeTimeModel : PagedResultRequestDto
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public bool IsActive { get; set; }
    }
}
