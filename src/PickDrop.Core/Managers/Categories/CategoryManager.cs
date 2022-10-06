using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PickDrop.Entities.Admin.Categories;
using PickDrop.Models.Categories;
using PickDrop.Utitlities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {

        private readonly IRepository<Category> _CategoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _CategoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<PagedResultDto<CategoryModel>> GetHistoryAsync(PagedCategoryModel input)
        {
            var allHistory = _CategoryRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Name.ToLower()))
                .WhereIf(!input.IsActive.IsNullOrWhiteSpace(), x => x.IsActive.ToString().ToLower().Contains(input.IsActive.ToLower()))
                .OrderByDescending(a => a.Id);
            var pagedallHistory = allHistory
                        .PageBy(input);
            var pagedAllHistory = await (from o in pagedallHistory
                                         select new CategoryModel()
                                         {
                                             Id = o.Id,
                                             Name = o.Name,
                                             Description = o.Description,
                                             ImagePath = o.ImagePath,
                                             ThumbnailImagePath = o.ThumbnailImagePath,
                                             IsActive = o.IsActive,
                                         }).ToListAsync();

            var totalCount = await allHistory.CountAsync();

            return new PagedResultDto<CategoryModel>(
                totalCount,
                pagedAllHistory
            );
        }

        public async Task<List<SelectItemDto>> GetCategoryList()
        {
            var list = await _CategoryRepository.GetAll().Select(x => new SelectItemDto()
            {
                Label = x.Name,
                Value = x.Id
            }).ToListAsync();
            return list;
        }


        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            return await _CategoryRepository.GetAll().Where(o => o.Id == id).Select(o => new CategoryModel()
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                ImagePath = o.ImagePath,
                ThumbnailImagePath = o.ThumbnailImagePath,
                IsActive = o.IsActive,
                TenantId = o.TenantId,
            }).FirstOrDefaultAsync();
        }

        public async Task<string> AddFiles(IFormFile file, long userId)
        {
            string fileName = "";
            string filePath = "";
            if (file.Length > 0)
            {
                //long UserId = userId; //Convert.ToInt32(AbpSession.UserId);
                //int i = 0;
                var currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // TODO: Deperate Folder by tenants and forms

                currentDirectory = currentDirectory + "\\wwwroot\\Attachments";
                string directoryPath = currentDirectory;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                filePath = Path.Combine(directoryPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return fileName;
        }

        public void DeleteFile(string imageName)
        {
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            var filePath = currentDirectory + "\\wwwroot\\Attachments\\" + imageName;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


       


        public async Task<int> AddCategoryAsync(CategoryModel input)
        {
            var Subcategory = _mapper.Map<Category>(input);
            return await _CategoryRepository.InsertAndGetIdAsync(Subcategory);
        }

        public async Task<int> UpdateCategoryAsync(CategoryModel input)
        {
            var Subcategory = _mapper.Map<Category>(input);
            return await _CategoryRepository.InsertOrUpdateAndGetIdAsync(Subcategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _CategoryRepository.DeleteAsync(id);
        }

    }
}
