using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SizeTypeTable
    {
        public SizeTypeTable()
        {
            SizeTypeByLeveTables = new HashSet<SizeTypeByLeveTable>();
        }

        public int SizeTypeId { get; set; }
        public string SizeType { get; set; } = null!;

        public virtual ICollection<SizeTypeByLeveTable> SizeTypeByLeveTables { get; set; }
    }
}
