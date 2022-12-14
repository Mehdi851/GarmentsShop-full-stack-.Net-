using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class MainCategoryTable
    {
        public MainCategoryTable()
        {
            SubCategoryTables = new HashSet<SubCategoryTable>();
        }

        public int MainCategoryId { get; set; }
        public string MainCategoryTitle { get; set; } = null!;
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan CreatedTime { get; set; }
        public int StatusId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<SubCategoryTable> SubCategoryTables { get; set; }
    }
}
