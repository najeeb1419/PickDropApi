using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Entities.Admin.Categories
{
    public class Category : FullAuditedEntity<int>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailImagePath { get; set; }
        public bool IsActive { get; set; }
    }
}
