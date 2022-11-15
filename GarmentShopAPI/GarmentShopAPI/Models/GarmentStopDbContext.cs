using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GarmentShopAPI.Models
{
    public partial class GarmentStopDbContext : DbContext
    {
        public GarmentStopDbContext()
        {
        }

        public GarmentStopDbContext(DbContextOptions<GarmentStopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressTypeTable> AddressTypeTables { get; set; } = null!;
        public virtual DbSet<BankAccountTable> BankAccountTables { get; set; } = null!;
        public virtual DbSet<BrandTable> BrandTables { get; set; } = null!;
        public virtual DbSet<CartTable> CartTables { get; set; } = null!;
        public virtual DbSet<ColorTypeTable> ColorTypeTables { get; set; } = null!;
        public virtual DbSet<CustomerReviewImage> CustomerReviewImages { get; set; } = null!;
        public virtual DbSet<CustomerReviewTable> CustomerReviewTables { get; set; } = null!;
        public virtual DbSet<DicountTable> DicountTables { get; set; } = null!;
        public virtual DbSet<GenderTable> GenderTables { get; set; } = null!;
        public virtual DbSet<MainCategoryTable> MainCategoryTables { get; set; } = null!;
        public virtual DbSet<OrderDetailTable> OrderDetailTables { get; set; } = null!;
        public virtual DbSet<OrderHeaderTable> OrderHeaderTables { get; set; } = null!;
        public virtual DbSet<OrderPaymentTable> OrderPaymentTables { get; set; } = null!;
        public virtual DbSet<OrderStatusTable> OrderStatusTables { get; set; } = null!;
        public virtual DbSet<PaymentStatusTable> PaymentStatusTables { get; set; } = null!;
        public virtual DbSet<PaymentTypeTable> PaymentTypeTables { get; set; } = null!;
        public virtual DbSet<ProductCompareTable> ProductCompareTables { get; set; } = null!;
        public virtual DbSet<ProductDetailsTable> ProductDetailsTables { get; set; } = null!;
        public virtual DbSet<ProductFeaturesTable> ProductFeaturesTables { get; set; } = null!;
        public virtual DbSet<ProductHeaderTable> ProductHeaderTables { get; set; } = null!;
        public virtual DbSet<ProductTagTable> ProductTagTables { get; set; } = null!;
        public virtual DbSet<SeasonDiscount> SeasonDiscounts { get; set; } = null!;
        public virtual DbSet<SeasonTable> SeasonTables { get; set; } = null!;
        public virtual DbSet<ShippingFeeTable> ShippingFeeTables { get; set; } = null!;
        public virtual DbSet<SizeLevelTable> SizeLevelTables { get; set; } = null!;
        public virtual DbSet<SizeTypeByLeveTable> SizeTypeByLeveTables { get; set; } = null!;
        public virtual DbSet<SizeTypeTable> SizeTypeTables { get; set; } = null!;
        public virtual DbSet<StatusTable> StatusTables { get; set; } = null!;
        public virtual DbSet<SubCategoryTable> SubCategoryTables { get; set; } = null!;
        public virtual DbSet<TagTable> TagTables { get; set; } = null!;
        public virtual DbSet<UnitTable> UnitTables { get; set; } = null!;
        public virtual DbSet<UserAddress> UserAddresses { get; set; } = null!;
        public virtual DbSet<UserCityTable> UserCityTables { get; set; } = null!;
        public virtual DbSet<UserCountryTable> UserCountryTables { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;
        public virtual DbSet<UserTypeTable> UserTypeTables { get; set; } = null!;
        public virtual DbSet<WishListTable> WishListTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= (localdb)\\mssqllocaldb;Database=GarmentStopDb; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressTypeTable>(entity =>
            {
                entity.HasKey(e => e.AddressTypeId);

                entity.ToTable("AddressTypeTable");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AddressType).HasMaxLength(250);
            });

            modelBuilder.Entity<BankAccountTable>(entity =>
            {
                entity.HasKey(e => e.BankAccountId);

                entity.ToTable("BankAccountTable");

                entity.Property(e => e.BankAccountId).HasColumnName("BankAccountID");

                entity.Property(e => e.AccountTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AcountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankName).HasMaxLength(500);

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.Ibanno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IBANNo");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.BankAccountTables)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccountTable_UserTable");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.BankAccountTables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccountTable_PaymentTypeTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.BankAccountTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccountTable_StatusTable");
            });

            modelBuilder.Entity<BrandTable>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("BrandTable");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandImage).HasMaxLength(500);

                entity.Property(e => e.BrandLogo).HasMaxLength(500);

                entity.Property(e => e.BrandTitle).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.BrandTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandTable_StatusTable");
            });

            modelBuilder.Entity<CartTable>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("CartTable");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.CartTables)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartTable_DicountTable");

                entity.HasOne(d => d.ProductDetails)
                    .WithMany(p => p.CartTables)
                    .HasForeignKey(d => d.ProductDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartTable_ProductDetailsTable");
            });

            modelBuilder.Entity<ColorTypeTable>(entity =>
            {
                entity.HasKey(e => e.ColorTypeId);

                entity.ToTable("ColorTypeTable");

                entity.Property(e => e.ColorTypeId).HasColumnName("ColorTypeID");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ColorTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ColorTypeTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ColorTypeTable_StatusTable");
            });

            modelBuilder.Entity<CustomerReviewImage>(entity =>
            {
                entity.ToTable("CustomerReviewImage");

                entity.Property(e => e.CustomerReviewImageId).HasColumnName("CustomerReviewImageID");

                entity.Property(e => e.CustomerReviewId).HasColumnName("CustomerReviewID");

                entity.Property(e => e.ImagePath).HasMaxLength(500);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.CustomerReview)
                    .WithMany(p => p.CustomerReviewImages)
                    .HasForeignKey(d => d.CustomerReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewImage_CustomerReviewTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CustomerReviewImages)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewImage_StatusTable");
            });

            modelBuilder.Entity<CustomerReviewTable>(entity =>
            {
                entity.HasKey(e => e.CustomerReviewId);

                entity.ToTable("CustomerReviewTable");

                entity.Property(e => e.CustomerReviewId).HasColumnName("CustomerReviewID");

                entity.Property(e => e.CustomerReview).HasMaxLength(500);

                entity.Property(e => e.CustomerReviewImageId).HasColumnName("CustomerReviewImageID");

                entity.Property(e => e.CustomerReviewUserId).HasColumnName("CustomerReviewUserID");

                entity.Property(e => e.OrderHeaderId).HasColumnName("OrderHeaderID");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.CustomerReviewImage)
                    .WithMany(p => p.CustomerReviewTables)
                    .HasForeignKey(d => d.CustomerReviewImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewTable_CustomerReviewImage");

                entity.HasOne(d => d.CustomerReviewUser)
                    .WithMany(p => p.CustomerReviewTables)
                    .HasForeignKey(d => d.CustomerReviewUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewTable_UserTable");

                entity.HasOne(d => d.OrderHeader)
                    .WithMany(p => p.CustomerReviewTables)
                    .HasForeignKey(d => d.OrderHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewTable_OrderHeaderTable");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.CustomerReviewTables)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewTable_ProductHeaderTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CustomerReviewTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerReviewTable_StatusTable");
            });

            modelBuilder.Entity<DicountTable>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("DicountTable");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.DiscountTitle).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedBy_UserID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.DicountTableCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DicountTable_UserTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.DicountTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DicountTable_StatusTable");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.DicountTableUpdatedByUsers)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DicountTable_UserTable1");
            });

            modelBuilder.Entity<GenderTable>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("GenderTable");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MainCategoryTable>(entity =>
            {
                entity.HasKey(e => e.MainCategoryId);

                entity.ToTable("Main_CategoryTable");

                entity.Property(e => e.MainCategoryId).HasColumnName("Main_CategoryID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.MainCategoryTitle)
                    .HasMaxLength(250)
                    .HasColumnName("Main_CategoryTitle");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.MainCategoryTables)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_CategoryTable_UserTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MainCategoryTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_CategoryTable_StatusTable");
            });

            modelBuilder.Entity<OrderDetailTable>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.ToTable("OrderDetailTable");

                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.OrderHeaderId).HasColumnName("OrderHeaderID");

                entity.Property(e => e.ProductDetailId).HasColumnName("ProductDetailID");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.OrderDetailTables)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailTable_DicountTable");

                entity.HasOne(d => d.OrderHeader)
                    .WithMany(p => p.OrderDetailTables)
                    .HasForeignKey(d => d.OrderHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailTable_OrderHeaderTable");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.OrderDetailTables)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailTable_ProductDetailsTable");
            });

            modelBuilder.Entity<OrderHeaderTable>(entity =>
            {
                entity.HasKey(e => e.OrderHeaderId);

                entity.ToTable("OrderHeaderTable");

                entity.Property(e => e.OrderHeaderId).HasColumnName("OrderHeaderID");

                entity.Property(e => e.CustomerUserId).HasColumnName("Customer_UserID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.ShippingDate).HasColumnType("date");

                entity.Property(e => e.ShippingFeeId).HasColumnName("ShippingFeeID");

                entity.Property(e => e.TransectionDate).HasColumnType("date");

                entity.Property(e => e.TransectionNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddressId).HasColumnName("UserAddressID");

                entity.HasOne(d => d.CustomerUser)
                    .WithMany(p => p.OrderHeaderTables)
                    .HasForeignKey(d => d.CustomerUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeaderTable_UserTable");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderHeaderTables)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeaderTable_OrderStatusTable");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.OrderHeaderTables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeaderTable_PaymentTypeTable");

                entity.HasOne(d => d.ShippingFee)
                    .WithMany(p => p.OrderHeaderTables)
                    .HasForeignKey(d => d.ShippingFeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeaderTable_ShippingFeeTable");

                entity.HasOne(d => d.UserAddress)
                    .WithMany(p => p.OrderHeaderTables)
                    .HasForeignKey(d => d.UserAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeaderTable_UserAddress");
            });

            modelBuilder.Entity<OrderPaymentTable>(entity =>
            {
                entity.HasKey(e => e.OrderPaymentId);

                entity.ToTable("OrderPaymentTable");

                entity.Property(e => e.OrderPaymentId).HasColumnName("OrderPaymentID");

                entity.Property(e => e.OrderHeaderId).HasColumnName("OrderHeaderID");

                entity.Property(e => e.PaymentGetways).HasMaxLength(500);

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.HasOne(d => d.OrderHeader)
                    .WithMany(p => p.OrderPaymentTables)
                    .HasForeignKey(d => d.OrderHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderPaymentTable_OrderHeaderTable");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.OrderPaymentTables)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderPaymentTable_PaymentStatusTable");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.OrderPaymentTables)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderPaymentTable_PaymentTypeTable");
            });

            modelBuilder.Entity<OrderStatusTable>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId);

                entity.ToTable("OrderStatusTable");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.OrderStatusTitle).HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderStatusTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderStatusTable_StatusTable");
            });

            modelBuilder.Entity<PaymentStatusTable>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusId);

                entity.ToTable("PaymentStatusTable");

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentTypeTable>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);

                entity.ToTable("PaymentTypeTable");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCompareTable>(entity =>
            {
                entity.HasKey(e => e.ProductCompareId);

                entity.ToTable("ProductCompareTable");

                entity.Property(e => e.ProductCompareId).HasColumnName("ProductCompareID");

                entity.Property(e => e.CompareUserId).HasColumnName("CompareUserID");

                entity.Property(e => e.ProductDetailId).HasColumnName("ProductDetailID");

                entity.HasOne(d => d.CompareUser)
                    .WithMany(p => p.ProductCompareTables)
                    .HasForeignKey(d => d.CompareUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCompareTable_UserTable");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.ProductCompareTables)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCompareTable_ProductDetailsTable");
            });

            modelBuilder.Entity<ProductDetailsTable>(entity =>
            {
                entity.HasKey(e => e.ProductDetailsId);

                entity.ToTable("ProductDetailsTable");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.Property(e => e.BarCode).HasMaxLength(50);

                entity.Property(e => e.ColorTypeId).HasColumnName("ColorTypeID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.SizeTypeByLevelId).HasColumnName("SizeTypeByLevelID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdateByUserId).HasColumnName("UpdateBy_UserID");

                entity.HasOne(d => d.ColorType)
                    .WithMany(p => p.ProductDetailsTables)
                    .HasForeignKey(d => d.ColorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_ColorTypeTable");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ProductDetailsTableCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_StatusTable1");

                entity.HasOne(d => d.CreatedByUserNavigation)
                    .WithMany(p => p.ProductDetailsTableCreatedByUserNavigations)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_UserTable");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.ProductDetailsTables)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_ProductHeaderTable");

                entity.HasOne(d => d.SizeTypeByLevel)
                    .WithMany(p => p.ProductDetailsTables)
                    .HasForeignKey(d => d.SizeTypeByLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_SizeTypeByLeveTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProductDetailsTableStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_StatusTable");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ProductDetailsTables)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_UnitTable");

                entity.HasOne(d => d.UpdateByUser)
                    .WithMany(p => p.ProductDetailsTableUpdateByUsers)
                    .HasForeignKey(d => d.UpdateByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_StatusTable2");

                entity.HasOne(d => d.UpdateByUserNavigation)
                    .WithMany(p => p.ProductDetailsTableUpdateByUserNavigations)
                    .HasForeignKey(d => d.UpdateByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetailsTable_UserTable1");
            });

            modelBuilder.Entity<ProductFeaturesTable>(entity =>
            {
                entity.HasKey(e => e.ProductFeatureId);

                entity.ToTable("ProductFeaturesTable");

                entity.Property(e => e.ProductFeatureId).HasColumnName("ProductFeatureID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedBy_UserID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ProductFeaturesTableCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFeaturesTable_UserTable");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.ProductFeaturesTables)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFeaturesTable_ProductHeaderTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProductFeaturesTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFeaturesTable_StatusTable");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ProductFeaturesTableUpdatedByUsers)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFeaturesTable_UserTable1");
            });

            modelBuilder.Entity<ProductHeaderTable>(entity =>
            {
                entity.HasKey(e => e.ProductHeaderId);

                entity.ToTable("ProductHeaderTable");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.ProductTitle).HasMaxLength(250);

                entity.Property(e => e.Skucode)
                    .HasMaxLength(50)
                    .HasColumnName("SKUCode");

                entity.Property(e => e.SubCategoryId).HasColumnName("Sub_CategoryID");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedBy_UserID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductHeaderTables)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHeaderTable_BrandTable");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ProductHeaderTableCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHeaderTable_UserTable");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.ProductHeaderTables)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHeaderTable_Sub_CategoryTable");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ProductHeaderTableUpdatedByUsers)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHeaderTable_UserTable1");
            });

            modelBuilder.Entity<ProductTagTable>(entity =>
            {
                entity.HasKey(e => e.ProductTagId);

                entity.ToTable("ProductTagTable");

                entity.Property(e => e.ProductTagId).HasColumnName("ProductTagID");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.ProductTagTables)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTagTable_ProductHeaderTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProductTagTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTagTable_StatusTable");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTagTables)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTagTable_TagTable");
            });

            modelBuilder.Entity<SeasonDiscount>(entity =>
            {
                entity.ToTable("SeasonDiscount");

                entity.Property(e => e.SeasonDiscountId).HasColumnName("SeasonDiscountID");

                entity.Property(e => e.DiscountPercent).HasColumnName("Discount_Percent");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.SeasonDiscounts)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonDiscount_ProductHeaderTable");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SeasonDiscounts)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonDiscount_SeasonTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SeasonDiscounts)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonDiscount_StatusTable");
            });

            modelBuilder.Entity<SeasonTable>(entity =>
            {
                entity.HasKey(e => e.SeasonId);

                entity.ToTable("SeasonTable");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.SeasonEndDate).HasColumnType("date");

                entity.Property(e => e.SeasonStartDate).HasColumnType("date");

                entity.Property(e => e.SeasonTitle).HasMaxLength(250);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.SeasonTables)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonTable_UserTable");
            });

            modelBuilder.Entity<ShippingFeeTable>(entity =>
            {
                entity.HasKey(e => e.ShippingFeeId);

                entity.ToTable("ShippingFeeTable");

                entity.Property(e => e.ShippingFeeId).HasColumnName("ShippingFeeID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ShippingFeeTables)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShippingFeeTable_UserCityTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ShippingFeeTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShippingFeeTable_StatusTable");
            });

            modelBuilder.Entity<SizeLevelTable>(entity =>
            {
                entity.HasKey(e => e.SizeLevelId);

                entity.ToTable("SizeLevelTable");

                entity.Property(e => e.SizeLevelId).HasColumnName("SizeLevelID");

                entity.Property(e => e.SizeLevel)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SizeTypeByLeveTable>(entity =>
            {
                entity.HasKey(e => e.SizeTypeByLeveId);

                entity.ToTable("SizeTypeByLeveTable");

                entity.Property(e => e.SizeTypeByLeveId).HasColumnName("SizeTypeByLeveID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.SizeLevelId).HasColumnName("SizeLevelID");

                entity.Property(e => e.SizeLevelValue).HasMaxLength(250);

                entity.Property(e => e.SizeTypeId).HasColumnName("SizeTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.SizeTypeByLeveTables)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeTypeByLeveTable_GenderTable");

                entity.HasOne(d => d.SizeLevel)
                    .WithMany(p => p.SizeTypeByLeveTables)
                    .HasForeignKey(d => d.SizeLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeTypeByLeveTable_SizeLevelTable");

                entity.HasOne(d => d.SizeType)
                    .WithMany(p => p.SizeTypeByLeveTables)
                    .HasForeignKey(d => d.SizeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeTypeByLeveTable_SizeTypeTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SizeTypeByLeveTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeTypeByLeveTable_StatusTable");
            });

            modelBuilder.Entity<SizeTypeTable>(entity =>
            {
                entity.HasKey(e => e.SizeTypeId);

                entity.ToTable("SizeTypeTable");

                entity.Property(e => e.SizeTypeId).HasColumnName("SizeTypeID");

                entity.Property(e => e.SizeType)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusTable>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("StatusTable");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategoryTable>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("Sub_CategoryTable");

                entity.Property(e => e.SubCategoryId).HasColumnName("Sub_CategoryID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedBy_UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.MainCategoryId).HasColumnName("Main_CategoryID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.SubCategoryTitle)
                    .HasMaxLength(250)
                    .HasColumnName("Sub_CategoryTitle");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.SubCategoryTables)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_CategoryTable_UserTable");

                entity.HasOne(d => d.MainCategory)
                    .WithMany(p => p.SubCategoryTables)
                    .HasForeignKey(d => d.MainCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_CategoryTable_Main_CategoryTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SubCategoryTables)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_CategoryTable_StatusTable");
            });

            modelBuilder.Entity<TagTable>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.ToTable("TagTable");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagTitle).HasMaxLength(250);
            });

            modelBuilder.Entity<UnitTable>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("UnitTable");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitTitle).HasMaxLength(250);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddress");

                entity.Property(e => e.UserAddressId).HasColumnName("UserAddressID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_AddressTypeTable");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_UserCityTable");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_StatusTable");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_UserTable");
            });

            modelBuilder.Entity<UserCityTable>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("UserCityTable");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(250);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UserCityTables)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCityTable_UserCountryTable");
            });

            modelBuilder.Entity<UserCountryTable>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("UserCountryTable");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryTitle).HasMaxLength(250);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("UserStatus");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTable");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_GenderTable");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_UserStatus");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_UserTypeTable");
            });

            modelBuilder.Entity<UserTypeTable>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("UserTypeTable");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserType).HasMaxLength(200);
            });

            modelBuilder.Entity<WishListTable>(entity =>
            {
                entity.HasKey(e => e.WishListId);

                entity.ToTable("WishListTable");

                entity.Property(e => e.WishListId).HasColumnName("WishListID");

                entity.Property(e => e.AddDate).HasColumnType("date");

                entity.Property(e => e.ProductHeaderId).HasColumnName("ProductHeaderID");

                entity.Property(e => e.WishListUserId).HasColumnName("WishList_UserID");

                entity.HasOne(d => d.ProductHeader)
                    .WithMany(p => p.WishListTables)
                    .HasForeignKey(d => d.ProductHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishListTable_ProductHeaderTable");

                entity.HasOne(d => d.WishListUser)
                    .WithMany(p => p.WishListTables)
                    .HasForeignKey(d => d.WishListUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishListTable_UserTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
