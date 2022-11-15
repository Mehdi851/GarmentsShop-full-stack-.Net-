using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ShippingFeeTable
    {
        public ShippingFeeTable()
        {
            OrderHeaderTables = new HashSet<OrderHeaderTable>();
        }

        public int ShippingFeeId { get; set; }
        public int CityId { get; set; }
        public double ShippingFee { get; set; }
        public int DeliveryTimeinDays { get; set; }
        public int StatusId { get; set; }

        public virtual UserCityTable City { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
    }
}
