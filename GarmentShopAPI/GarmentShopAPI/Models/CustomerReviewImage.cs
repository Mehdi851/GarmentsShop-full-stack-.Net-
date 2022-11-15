using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class CustomerReviewImage
    {
        public CustomerReviewImage()
        {
            CustomerReviewTables = new HashSet<CustomerReviewTable>();
        }

        public int CustomerReviewImageId { get; set; }
        public int CustomerReviewId { get; set; }
        public string ImagePath { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual CustomerReviewTable CustomerReview { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
    }
}
