using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.Categories
{
   public class PagedCategoryModel : PagedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}
