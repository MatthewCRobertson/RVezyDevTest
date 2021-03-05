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

        public List<ListingEntity> Search(SearchListing criteria)
        {
            return this.repo.Search(criteria);
        }

        public int Create(CreateListing createListing)
        {
            ListingEntity listing = new ListingEntity();

            listing.name = createListing.Name;
            listing.property_type = createListing.PropertyType;

            return this.repo.Create(listing);
        }

        public void Update(UpdateListing updateListing)
        {
            var listing = this.GetById(updateListing.ListingId);

            if(listing != null)
            {
                listing.property_type = updateListing.PropertyType;
                listing.name = updateListing.Name;

                this.repo.Update(listing);
            }
        }
    }
}
