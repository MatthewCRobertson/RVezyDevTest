using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Listing.Infrastructure
{
    public interface IListingRepository
    {
        ListingEntity GetById(int id);

        List<ListingEntity> Search(ListingSearch criteria);
    }
}
