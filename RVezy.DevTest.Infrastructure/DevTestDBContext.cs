using Microsoft.EntityFrameworkCore;
using RVezy.DevTest.Domain.Calendar.Model;
using RVezy.DevTest.Domain.Listing.Model;
using RVezy.DevTest.Domain.Review.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RVezy.DevTest.Infrastructure
{
    public class DevTestDBContext : DbContext
    {
        public DbSet<ListingEntity> Listings { get; set; }

        public DbSet<ReviewEntity> Reviews { get; set; }

        public DbSet<CalendarEntity> Calendar { get; set; }

        public DevTestDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
    }
}
