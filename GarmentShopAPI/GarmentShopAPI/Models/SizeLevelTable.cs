using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SizeLevelTable
    {
        public SizeLevelTable()
        {
            SizeTypeByLeveTables = new HashSet<SizeTypeByLeveTable>();
        }

        public int SizeLevelId { get; set; }
        public string SizeLevel { get; set; } = null!;

        public virtual ICollection<SizeTypeByLeveTable> SizeTypeByLeveTables { get; set; }
    }
}
