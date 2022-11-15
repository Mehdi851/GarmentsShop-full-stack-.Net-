using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class PaymentTypeTable
    {
        public PaymentTypeTable()
        {
            BankAccountTables = new HashSet<BankAccountTable>();
            OrderHeaderTables = new HashSet<OrderHeaderTable>();
            OrderPaymentTables = new HashSet<OrderPaymentTable>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentType { get; set; } = null!;

        public virtual ICollection<BankAccountTable> BankAccountTables { get; set; }
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
        public virtual ICollection<OrderPaymentTable> OrderPaymentTables { get; set; }
    }
}
