using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class OrderHeaderTable
    {
        public OrderHeaderTable()
        {
            CustomerReviewTables = new HashSet<CustomerReviewTable>();
            OrderDetailTables = new HashSet<OrderDetailTable>();
            OrderPaymentTables = new HashSet<OrderPaymentTable>();
        }

        public int OrderHeaderId { get; set; }
        public int CustomerUserId { get; set; }
        public int ShippingFeeId { get; set; }
        public int UserAddressId { get; set; }
        public double TotalCost { get; set; }
        public double DiscountAmount { get; set; }
        public double TotalPayment { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public DateTime ShippingDate { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public string? TransectionNo { get; set; }
        public DateTime? TransectionDate { get; set; }
        public TimeSpan? TransectionTime { get; set; }
        public string? PaymentReceiptSnapshort { get; set; }

        public virtual UserTable CustomerUser { get; set; } = null!;
        public virtual OrderStatusTable OrderStatus { get; set; } = null!;
        public virtual PaymentTypeTable PaymentType { get; set; } = null!;
        public virtual ShippingFeeTable ShippingFee { get; set; } = null!;
        public virtual UserAddress UserAddress { get; set; } = null!;
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
        public virtual ICollection<OrderDetailTable> OrderDetailTables { get; set; }
        public virtual ICollection<OrderPaymentTable> OrderPaymentTables { get; set; }
    }
}
