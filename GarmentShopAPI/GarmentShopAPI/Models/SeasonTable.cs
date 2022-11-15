using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SeasonTable
    {
        public SeasonTable()
        {
            SeasonDiscounts = new HashSet<SeasonDiscount>();
        }

        public int SeasonId { get; set; }
        public string SeasonTitle { get; set; } = null!;
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public int CreatedByUserId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual ICollection<SeasonDiscount> SeasonDiscounts { get; set; }
    }
}
