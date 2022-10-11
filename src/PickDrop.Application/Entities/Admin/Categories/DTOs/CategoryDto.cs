using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Entities.Admin.Categories;
using PickDrop.Models.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickDrop.Entites.Admin.Categories.DTOs
{
    [AutoMapFrom(typeof(CategoryModel)), AutoMapTo(typeof(CategoryModel))]

    public class CategoryDto : EntityDto<int>
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

        // Extra Properties
        public bool IsImageCahnged { get; set; }
        public string OldImagePath { get; set; }
        public bool IsThumbnailImageCahnged { get; set; }
        public string OldThumbnailImagePath { get; set; }
    }
}
