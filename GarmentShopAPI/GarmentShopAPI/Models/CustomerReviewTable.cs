using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class CustomerReviewTable
    {
        public CustomerReviewTable()
        {
            CustomerReviewImages = new HashSet<CustomerReviewImage>();
        }

        public int CustomerReviewId { get; set; }
        public int ProductHeaderId { get; set; }
        public string CustomerReview { get; set; } = null!;
        public int StatusId { get; set; }
        public int CustomerReviewUserId { get; set; }
        public int OrderHeaderId { get; set; }
        public int CustomerReviewImageId { get; set; }

        public virtual CustomerReviewImage CustomerReviewImage { get; set; } = null!;
        public virtual UserTable CustomerReviewUser { get; set; } = null!;
        public virtual OrderHeaderTable OrderHeader { get; set; } = null!;
        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<CustomerReviewImage> CustomerReviewImages { get; set; }
    }
}
