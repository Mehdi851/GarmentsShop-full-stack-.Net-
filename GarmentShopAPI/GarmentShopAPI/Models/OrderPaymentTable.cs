using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class OrderPaymentTable
    {
        public int OrderPaymentId { get; set; }
        public int OrderHeaderId { get; set; }
        public double TotalPayment { get; set; }
        public string PaymentGetways { get; set; } = null!;
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }

        public virtual OrderHeaderTable OrderHeader { get; set; } = null!;
        public virtual PaymentStatusTable PaymentStatus { get; set; } = null!;
        public virtual PaymentTypeTable PaymentType { get; set; } = null!;
    }
}
