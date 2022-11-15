using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class TagTable
    {
        public TagTable()
        {
            ProductTagTables = new HashSet<ProductTagTable>();
        }

        public int TagId { get; set; }
        public string TagTitle { get; set; } = null!;

        public virtual ICollection<ProductTagTable> ProductTagTables { get; set; }
    }
}
