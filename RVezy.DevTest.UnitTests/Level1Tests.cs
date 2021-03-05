using NUnit.Framework;
using RVezy.DevTest.Domain.Listing.Service;
using RVezy.DevTest.Infrastructure.Listing;
using RVezy.Test.WebAPI.Controllers;
using System.IO;
using System.Linq;

namespace RVezy.DevTest.UnitTests
{
    public class Level1Tests
    {
        ListingController listingController;

        [SetUp]
        public void Setup()
        {
            FileInfo listingData = new FileInfo("TestData\\listings.csv");

            var text = File.ReadAllText(listingData.FullName);

            ListingCSVFileRepository repo = new ListingCSVFileRepository(listingData);
            ListingService service = new ListingService(repo);
            listingController = new ListingController(service);


        }

        [Test]
        public void SearchAndGets()
        {
            var entity = listingController.Get(241032);

            Assert.IsTrue(entity.id == 241032);

            var searchResult = listingController.Search(0, 100, "Apartment");

            Assert.IsTrue(searchResult.Count <= 100);
            Assert.IsTrue(searchResult.Where(x => x.property_type != "Apartment").Count() == 0);
        }
    }
}