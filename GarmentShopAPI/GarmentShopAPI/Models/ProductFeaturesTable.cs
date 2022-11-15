using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ProductFeaturesTable
    {
        public int ProductFeatureId { get; set; }
        public int ProductHeaderId { get; set; }
        public string ProductFeature { get; set; } = null!;
        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
        public int StatusId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual UserTable UpdatedByUser { get; set; } = null!;
    }
}
