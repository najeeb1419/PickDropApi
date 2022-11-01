using Abp.Application.Editions;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using PickDrop.Editions;
using PickDrop.Entities.Admin.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.EntityFrameworkCore.Seed.Host
{
    public class DefaultCategoriesCreator
    {
        private readonly PickDropDbContext _context;
        List<string> categoryList = new List<string>();
        public DefaultCategoriesCreator(PickDropDbContext context)
        {
            _context = context;
            GetDefaultCategoryList();
        }

       private List<string> GetDefaultCategoryList()
        {
            categoryList.Add("Car");
            categoryList.Add("Bike");
            categoryList.Add("Bus");
            return categoryList;
        }


        public void Create()
        {
            CreateCategory();
        }

        private void CreateCategory()
        {
            foreach (var item in categoryList)
            {
                var defaultCategory = _context.Categories.IgnoreQueryFilters().FirstOrDefault(e => e.Name == item);
                if (defaultCategory == null)
                {
                    defaultCategory = new Category { Name = item, IsActive = true , TenantId= 1 };
                    _context.Categories.Add(defaultCategory);
                    _context.SaveChanges();
                }
            }
            
        }


    }
}
