using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int StatusId { get; set; }
        public string StatusTitle { get; set; } = null!;

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
