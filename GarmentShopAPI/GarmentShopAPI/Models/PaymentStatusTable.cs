using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class PaymentStatusTable
    {
        public PaymentStatusTable()
        {
            OrderPaymentTables = new HashSet<OrderPaymentTable>();
        }

        public int PaymentStatusId { get; set; }
        public string PaymentStatus { get; set; } = null!;

        public virtual ICollection<OrderPaymentTable> OrderPaymentTables { get; set; }
    }
}
