using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Listing.InputModels
{
    public class UpdateListing
    {
        public int ListingId { get; set; }

        public string Name { get; set; }

        public string PropertyType { get; set; }
    }
}
