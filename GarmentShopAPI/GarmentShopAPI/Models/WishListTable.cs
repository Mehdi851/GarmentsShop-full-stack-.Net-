using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class WishListTable
    {
        public int WishListId { get; set; }
        public int WishListUserId { get; set; }
        public int ProductHeaderId { get; set; }
        public DateTime AddDate { get; set; }

        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual UserTable WishListUser { get; set; } = null!;
    }
}
