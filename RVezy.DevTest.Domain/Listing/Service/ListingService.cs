using RVezy.DevTest.Domain.Listing.Infrastructure;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Listing.Service
{
    public class ListingService
    {
        private IListingRepository repo;

        public ListingService(IListingRepository repo)
        {
            this.repo = repo;
        }

        public ListingEntity GetById(int id)
        {
            return this.repo.GetById(id);
        }

        public List<ListingEntity> Search(ListingSearch criteria)
        {
            return this.repo.Search(criteria);
        }
    }
}
