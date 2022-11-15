using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SubCategoryTable
    {
        public SubCategoryTable()
        {
            ProductHeaderTables = new HashSet<ProductHeaderTable>();
        }

        public int SubCategoryId { get; set; }
        public int MainCategoryId { get; set; }
        public string SubCategoryTitle { get; set; } = null!;
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan CreatedTime { get; set; }
        public int StatusId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual MainCategoryTable MainCategory { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<ProductHeaderTable> ProductHeaderTables { get; set; }
    }
}
