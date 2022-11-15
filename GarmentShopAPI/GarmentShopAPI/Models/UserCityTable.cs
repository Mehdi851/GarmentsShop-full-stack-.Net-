using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserCityTable
    {
        public UserCityTable()
        {
            ShippingFeeTables = new HashSet<ShippingFeeTable>();
            UserAddresses = new HashSet<UserAddress>();
        }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual UserCountryTable Country { get; set; } = null!;
        public virtual ICollection<ShippingFeeTable> ShippingFeeTables { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
