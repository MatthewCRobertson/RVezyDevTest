using NUnit.Framework;
using RVezy.DevTest.Domain.Listing.Service;
using RVezy.DevTest.Infrastructure.Listing;
using RVezy.Test.WebAPI.Controllers;
using System.IO;

namespace RVezy.DevTest.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            FileInfo listingData = new FileInfo("TestData\\listings.csv");

            var text = File.ReadAllText(listingData.FullName);

            ListingCSVFileRepository repo = new ListingCSVFileRepository(listingData);
            ListingService service = new ListingService(repo);
            ListingController listingController = new ListingController(service);

            var entity = listingController.Get(241032);

            Assert.IsTrue(entity.id == 241032);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}