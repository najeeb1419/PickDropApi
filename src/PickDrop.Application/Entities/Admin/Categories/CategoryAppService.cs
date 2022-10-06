using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickDrop.Entites.Admin.Categories.DTOs;
using PickDrop.Entities.Admin.Categories.DTOs;
using PickDrop.Managers.Categories;
using PickDrop.Models.Categories;
using PickDrop.Utitlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto>, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryAppService(
            IRepository<Category, int> respository,
            ICategoryManager categoryManager
            ) : base(respository)
        {
            _categoryManager = categoryManager;
        }


        public async Task<PagedResultDto<CategoryDto>> GetHistory(PagedCategoryResultRequestDto input)
        {
            var data = await _categoryManager.GetHistoryAsync(ObjectMapper.Map<PagedCategoryModel>(input));
            var finalResult = new PagedResultDto<CategoryDto>();
            finalResult.Items = ObjectMapper.Map<List<CategoryDto>>(data.Items);
            finalResult.TotalCount = data.TotalCount;
            return finalResult;
        }


        public async Task<string> AddFile(IFormFile input)
        {
            var tenantName = AbpSession.TenantId;
            var data = await _categoryManager.AddFiles(input, AbpSession.UserId != null ? AbpSession.UserId.Value : 0);
            return data;
        }

        public override Task<CategoryDto> UpdateAsync(CategoryDto input)
        {
            if (input.IsImageCahnged)
            {
                _categoryManager.DeleteFile(input.OldImagePath);
            }

            if (input.IsThumbnailImageCahnged)
            {
                _categoryManager.DeleteFile(input.OldThumbnailImagePath);
            }


            return base.UpdateAsync(input);
        }


        [HttpPost]
        public Task DeleteCategory(CategoryDto input)
        {
            if (input.ImagePath != null)
            {
                _categoryManager.DeleteFile(input.ImagePath);
            }

            if (input.ThumbnailImagePath != null)
            {
                _categoryManager.DeleteFile(input.ThumbnailImagePath);
            }

            return base.DeleteAsync(input);
        }

        public async Task<List<SelectItemDto>> GetCategoryList()
        {
            var list = await _categoryManager.GetCategoryList();
            return list;
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var data = await _categoryManager.GetCategoryAsync(id);
            return ObjectMapper.Map<CategoryDto>(data);
        }

        public async Task<int> AddCategoryAsync(CategoryDto input)
        {
            var data = ObjectMapper.Map<CategoryModel>(input);
            return await _categoryManager.AddCategoryAsync(data);
        }

        public async Task<int> UpdateProuductSubCategoryAsync(CategoryDto input)
        {
            var data = ObjectMapper.Map<CategoryModel>(input);
            return await _categoryManager.UpdateCategoryAsync(data);
        }

        public async Task DeleteProuductSubCategoryAsync(int id)
        {
            await _categoryManager.DeleteCategoryAsync(id);
        }
    }
}
