using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class GenderTable
    {
        public GenderTable()
        {
            SizeTypeByLeveTables = new HashSet<SizeTypeByLeveTable>();
            UserTables = new HashSet<UserTable>();
        }

        public int GenderId { get; set; }
        public string GenderTitle { get; set; } = null!;

        public virtual ICollection<SizeTypeByLeveTable> SizeTypeByLeveTables { get; set; }
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
