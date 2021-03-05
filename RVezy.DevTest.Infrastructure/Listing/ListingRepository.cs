using RVezy.DevTest.Domain.Listing.Infrastructure;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Infrastructure.Listing
{
    public class ListingRepository : IListingRepository
    {
        public void Create(ListingEntity listing)
        {
            throw new NotImplementedException();
        }

        public ListingEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListingEntity> Search(SearchListing criteria)
        {
            throw new NotImplementedException();
        }

        public void Update(ListingEntity listing)
        {
            throw new NotImplementedException();
        }
    }
}
