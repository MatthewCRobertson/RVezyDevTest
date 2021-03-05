using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RVezy.DevTest.Domain.Listing.Infrastructure;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Service;
using RVezy.DevTest.Infrastructure;
using RVezy.DevTest.Infrastructure.Listing;
using RVezy.Test.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVezy.DevTest.UnitTests
{
    public class Level2Tests
    {
        ServiceProvider provider;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DevTestDBContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()),
                    ServiceLifetime.Scoped,
                    ServiceLifetime.Scoped);

            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<ListingService, ListingService>();
            services.AddScoped<ListingController, ListingController>();

            provider = services.BuildServiceProvider();
        }

        [Test]
        public void CreateAndUpdate()
        {
            var listingController = provider.GetService<ListingController>();

            CreateListing cl = new CreateListing();

            cl.Name = "Test Listing";
            cl.PropertyType = "Condo";

            var newListingId = listingController.Create(cl);


            UpdateListing updateListing = new UpdateListing();

            updateListing.ListingId = 1;
            updateListing.Name = "Test Listing";
            updateListing.PropertyType = "Apartment";

            listingController.Update(updateListing);

            Assert.IsTrue(updateListing.PropertyType == listingController.Get(1).property_type);
        }
    }
}
