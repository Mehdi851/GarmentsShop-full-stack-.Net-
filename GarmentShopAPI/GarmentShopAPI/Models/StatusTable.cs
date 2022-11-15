using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class StatusTable
    {
        public StatusTable()
        {
            BankAccountTables = new HashSet<BankAccountTable>();
            BrandTables = new HashSet<BrandTable>();
            ColorTypeTables = new HashSet<ColorTypeTable>();
            CustomerReviewImages = new HashSet<CustomerReviewImage>();
            CustomerReviewTables = new HashSet<CustomerReviewTable>();
            DicountTables = new HashSet<DicountTable>();
            MainCategoryTables = new HashSet<MainCategoryTable>();
            OrderStatusTables = new HashSet<OrderStatusTable>();
            ProductDetailsTableCreatedByUsers = new HashSet<ProductDetailsTable>();
            ProductDetailsTableStatuses = new HashSet<ProductDetailsTable>();
            ProductDetailsTableUpdateByUsers = new HashSet<ProductDetailsTable>();
            ProductFeaturesTables = new HashSet<ProductFeaturesTable>();
            ProductTagTables = new HashSet<ProductTagTable>();
            SeasonDiscounts = new HashSet<SeasonDiscount>();
            ShippingFeeTables = new HashSet<ShippingFeeTable>();
            SizeTypeByLeveTables = new HashSet<SizeTypeByLeveTable>();
            SubCategoryTables = new HashSet<SubCategoryTable>();
            UserAddresses = new HashSet<UserAddress>();
        }

        public int StatusId { get; set; }
        public string StatusTitle { get; set; } = null!;

        public virtual ICollection<BankAccountTable> BankAccountTables { get; set; }
        public virtual ICollection<BrandTable> BrandTables { get; set; }
        public virtual ICollection<ColorTypeTable> ColorTypeTables { get; set; }
        public virtual ICollection<CustomerReviewImage> CustomerReviewImages { get; set; }
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
        public virtual ICollection<DicountTable> DicountTables { get; set; }
        public virtual ICollection<MainCategoryTable> MainCategoryTables { get; set; }
        public virtual ICollection<OrderStatusTable> OrderStatusTables { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTableCreatedByUsers { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTableStatuses { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTableUpdateByUsers { get; set; }
        public virtual ICollection<ProductFeaturesTable> ProductFeaturesTables { get; set; }
        public virtual ICollection<ProductTagTable> ProductTagTables { get; set; }
        public virtual ICollection<SeasonDiscount> SeasonDiscounts { get; set; }
        public virtual ICollection<ShippingFeeTable> ShippingFeeTables { get; set; }
        public virtual ICollection<SizeTypeByLeveTable> SizeTypeByLeveTables { get; set; }
        public virtual ICollection<SubCategoryTable> SubCategoryTables { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
