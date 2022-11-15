using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            BankAccountTables = new HashSet<BankAccountTable>();
            CustomerReviewTables = new HashSet<CustomerReviewTable>();
            DicountTableCreatedByUsers = new HashSet<DicountTable>();
            DicountTableUpdatedByUsers = new HashSet<DicountTable>();
            MainCategoryTables = new HashSet<MainCategoryTable>();
            OrderHeaderTables = new HashSet<OrderHeaderTable>();
            ProductCompareTables = new HashSet<ProductCompareTable>();
            ProductDetailsTableCreatedByUserNavigations = new HashSet<ProductDetailsTable>();
            ProductDetailsTableUpdateByUserNavigations = new HashSet<ProductDetailsTable>();
            ProductFeaturesTableCreatedByUsers = new HashSet<ProductFeaturesTable>();
            ProductFeaturesTableUpdatedByUsers = new HashSet<ProductFeaturesTable>();
            ProductHeaderTableCreatedByUsers = new HashSet<ProductHeaderTable>();
            ProductHeaderTableUpdatedByUsers = new HashSet<ProductHeaderTable>();
            SeasonTables = new HashSet<SeasonTable>();
            SubCategoryTables = new HashSet<SubCategoryTable>();
            UserAddresses = new HashSet<UserAddress>();
            WishListTables = new HashSet<WishListTable>();
        }

        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public int GenderId { get; set; }
        public int UserStatusId { get; set; }

        public virtual GenderTable Gender { get; set; } = null!;
        public virtual UserStatus UserStatus { get; set; } = null!;
        public virtual UserTypeTable UserType { get; set; } = null!;
        public virtual ICollection<BankAccountTable> BankAccountTables { get; set; }
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
        public virtual ICollection<DicountTable> DicountTableCreatedByUsers { get; set; }
        public virtual ICollection<DicountTable> DicountTableUpdatedByUsers { get; set; }
        public virtual ICollection<MainCategoryTable> MainCategoryTables { get; set; }
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
        public virtual ICollection<ProductCompareTable> ProductCompareTables { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTableCreatedByUserNavigations { get; set; }
        public virtual ICollection<ProductDetailsTable> ProductDetailsTableUpdateByUserNavigations { get; set; }
        public virtual ICollection<ProductFeaturesTable> ProductFeaturesTableCreatedByUsers { get; set; }
        public virtual ICollection<ProductFeaturesTable> ProductFeaturesTableUpdatedByUsers { get; set; }
        public virtual ICollection<ProductHeaderTable> ProductHeaderTableCreatedByUsers { get; set; }
        public virtual ICollection<ProductHeaderTable> ProductHeaderTableUpdatedByUsers { get; set; }
        public virtual ICollection<SeasonTable> SeasonTables { get; set; }
        public virtual ICollection<SubCategoryTable> SubCategoryTables { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<WishListTable> WishListTables { get; set; }
    }
}
