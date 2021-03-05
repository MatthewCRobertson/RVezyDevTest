using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Review.Model
{
    public class ReviewEntity
    {
        public int id { get; set; }
        public int listing_id { get; set; }
        public string date { get; set; }
        public int reviewer_id { get; set; }
        public string reviewer_name { get; set; }
        public string comments { get; set; }
    }
}
