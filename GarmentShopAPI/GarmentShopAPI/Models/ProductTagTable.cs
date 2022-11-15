using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ProductTagTable
    {
        public int ProductTagId { get; set; }
        public int ProductHeaderId { get; set; }
        public int TagId { get; set; }
        public int StatusId { get; set; }

        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual TagTable Tag { get; set; } = null!;
    }
}
