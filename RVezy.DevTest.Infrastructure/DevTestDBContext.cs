using Microsoft.EntityFrameworkCore;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Infrastructure
{
    public class DevTestDBContext : DbContext
    {
        public DbSet<ListingEntity> Listings { get; set; }

    }
}
