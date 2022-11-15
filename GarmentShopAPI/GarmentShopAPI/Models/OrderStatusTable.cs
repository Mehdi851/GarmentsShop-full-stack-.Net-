using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class OrderStatusTable
    {
        public OrderStatusTable()
        {
            OrderHeaderTables = new HashSet<OrderHeaderTable>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusTitle { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
    }
}
