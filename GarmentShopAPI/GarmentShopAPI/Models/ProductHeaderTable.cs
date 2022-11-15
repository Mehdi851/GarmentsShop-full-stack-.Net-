using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ProductHeaderTable
    {
        public ProductHeaderTable()
        {
            CustomerReviewTables = new HashSet<CustomerReviewTable>();
            ProductDetailsTables = new HashSet<ProductDetailsTable>();
            ProductFeaturesTables = new HashSet<ProductFeaturesTable>();
            ProductTagTables = new HashSet<ProductTagTable>();
            SeasonDiscounts = new HashSet<SeasonDiscount>();
            WishListTables = new HashSet<WishListTable>();
        }

        public int ProductHeaderId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductTitle { get; set; } = null!;
        public int BrandId { get; set; }
        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
        public string ProductInformation { get; set; } = null!;
        public string Skucode { get; set; } = null!;

        public virtual BrandTable Brand { get; set; } = null!;
        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual SubCategoryTable SubCategory { get; set; } = null!;
        public virtual UserTable UpdatedByUser { get; set; } = null!;
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTables { get; set; }
        public virtual ICollection<ProductFeaturesTable> ProductFeaturesTables { get; set; }
        public virtual ICollection<ProductTagTable> ProductTagTables { get; set; }
        public virtual ICollection<SeasonDiscount> SeasonDiscounts { get; set; }
        public virtual ICollection<WishListTable> WishListTables { get; set; }
    }
}
