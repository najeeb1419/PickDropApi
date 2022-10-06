﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PickDrop.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.Categories.DTOs
{
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        [AutoMapFrom(typeof(PagedCategoryModel)), AutoMapTo(typeof(PagedCategoryModel))]
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}