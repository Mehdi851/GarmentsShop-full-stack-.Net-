using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SeasonDiscount
    {
        public int SeasonDiscountId { get; set; }
        public int ProductHeaderId { get; set; }
        public int DiscountPercent { get; set; }
        public int StatusId { get; set; }
        public int SeasonId { get; set; }

        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual SeasonTable Season { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
    }
}
