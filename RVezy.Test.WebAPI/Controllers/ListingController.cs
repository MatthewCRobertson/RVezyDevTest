using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using RVezy.DevTest.Domain.Listing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVezy.Test.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private ListingService service;

        public ListingController(ListingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ListingEntity Get(int id)
        {
            return this.service.GetById(id);
        }

        [HttpGet("search")]
        public List<ListingEntity> Search(int offset, int limit, string propertyType)
        {
            SearchListing listingSearch = new SearchListing();

            listingSearch.Limit = limit;
            listingSearch.Offset = offset;
            listingSearch.PropertyType = propertyType;

            return this.service.Search(listingSearch);
        }

        [HttpPost]
        public void Create(CreateListing createListing)
        {
            this.service.Create(createListing);
        }

        [HttpPut]
        public void Update(UpdateListing updateListing)
        {
            this.service.Update(updateListing);
        }
    }
}
