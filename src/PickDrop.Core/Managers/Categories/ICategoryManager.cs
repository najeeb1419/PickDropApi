using Abp.Application.Services.Dto;
using Abp.Dependency;
using Microsoft.AspNetCore.Http;
using PickDrop.Models.Categories;
using PickDrop.Utitlities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickDrop.Managers.Categories
{
    public interface ICategoryManager:ITransientDependency
    {
        Task<PagedResultDto<CategoryModel>> GetHistoryAsync(PagedCategoryModel input);
        Task<CategoryModel> GetCategoryAsync(int id);

        Task<string> AddFiles(IFormFile file, long userId);
        Task<List<SelectItemDto>> GetCategoryList();
        //Task<bool> UploadFile(IFormFile file);

        void DeleteFile(string imageName);

        Task<int> AddCategoryAsync(CategoryModel input);
        Task<int> UpdateCategoryAsync(CategoryModel input);
        Task DeleteCategoryAsync(int id);
    }
}