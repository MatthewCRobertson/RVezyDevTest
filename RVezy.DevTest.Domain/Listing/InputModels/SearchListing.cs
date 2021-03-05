using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Listing.InputModels
{
    public class SearchListing
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public string PropertyType { get; set; }
    }
}
