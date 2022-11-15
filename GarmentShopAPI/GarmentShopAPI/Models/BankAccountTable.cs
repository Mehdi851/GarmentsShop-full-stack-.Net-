using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class BankAccountTable
    {
        public int BankAccountId { get; set; }
        public int PaymentTypeId { get; set; }
        public string BankName { get; set; } = null!;
        public string AccountTitle { get; set; } = null!;
        public string AcountNo { get; set; } = null!;
        public string Ibanno { get; set; } = null!;
        public int StatusId { get; set; }
        public int CreatedByUserId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual PaymentTypeTable PaymentType { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
    }
}
