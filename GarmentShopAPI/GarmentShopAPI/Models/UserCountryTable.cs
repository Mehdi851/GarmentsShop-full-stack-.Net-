using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserCountryTable
    {
        public UserCountryTable()
        {
            UserCityTables = new HashSet<UserCityTable>();
        }

        public int CountryId { get; set; }
        public string CountryTitle { get; set; } = null!;

        public virtual ICollection<UserCityTable> UserCityTables { get; set; }
    }
}
