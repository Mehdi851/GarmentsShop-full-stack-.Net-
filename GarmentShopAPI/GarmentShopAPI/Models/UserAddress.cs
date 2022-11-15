using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            OrderHeaderTables = new HashSet<OrderHeaderTable>();
        }

        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public int AddressTypeId { get; set; }
        public string FullAddress { get; set; } = null!;
        public int CityId { get; set; }
        public string PostalCode { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual AddressTypeTable AddressType { get; set; } = null!;
        public virtual UserCityTable City { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual UserTable User { get; set; } = null!;
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
    }
}
