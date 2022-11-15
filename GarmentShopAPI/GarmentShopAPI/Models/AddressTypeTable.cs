using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class AddressTypeTable
    {
        public AddressTypeTable()
        {
            UserAddresses = new HashSet<UserAddress>();
        }

        public int AddressTypeId { get; set; }
        public string AddressType { get; set; } = null!;

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
