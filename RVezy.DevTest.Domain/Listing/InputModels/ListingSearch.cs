using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Listing.InputModels
{
    public class ListingSearch
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public string PropertyType { get; set; }
    }
}
