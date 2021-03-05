using RVezy.DevTest.Domain.Listing.Infrastructure;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RVezy.DevTest.Infrastructure.Listing
{
    public class ListingRepository : IListingRepository
    {
        DevTestDBContext context;

        public ListingRepository(DevTestDBContext context)
        {
            this.context = context;
        }

        public int Create(ListingEntity listing)
        {
            this.context.Listings.Add(listing);
            this.context.SaveChanges();

            return listing.id;
        }

        public ListingEntity GetById(int id)
        {
            return this.context.Listings.Where(x => x.id == id).FirstOrDefault();
        }

        public List<ListingEntity> Search(SearchListing criteria)
        {
            return this.context.Listings
                .Where(x => x.property_type == criteria.PropertyType || criteria.PropertyType == null)
                .Skip(criteria.Offset)
                .Take(criteria.Limit)
                .ToList();
        }

        public void Update(ListingEntity listing)
        {
            var record = this.context.Listings
                            .Where(x => x.id == listing.id)
                            .FirstOrDefault();

            if(record != null)
            {
                record.name = listing.name;
                record.property_type = listing.property_type;
            }

            this.context.SaveChanges();
        }
    }
}
