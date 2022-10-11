using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Entities.Admin.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Models.Categories
{
    [AutoMapFrom(typeof(Category)), AutoMapTo(typeof(Category))]
    public class CategoryModel :EntityDto<int>
    {
        public virtual int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailImagePath { get; set; }
        public bool IsActive { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ParentId { get; set; }
        public virtual List<Category> Subcategories { get; set; }
    }
}
