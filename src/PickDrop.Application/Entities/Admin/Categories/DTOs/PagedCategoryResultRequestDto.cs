using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Models.Categories;

namespace PickDrop.Entities.Admin.Categories.DTOs
{
    [AutoMapFrom(typeof(PagedCategoryModel)), AutoMapTo(typeof(PagedCategoryModel))]
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string Type { get; set; }
    }
}
