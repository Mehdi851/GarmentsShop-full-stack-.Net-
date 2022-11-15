﻿using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserTypeTable
    {
        public UserTypeTable()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int UserTypeId { get; set; }
        public string UserType { get; set; } = null!;

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
