using System;
using Microsoft.EntityFrameworkCore;
using shared_library.Servers;

namespace shared_library.Contexts
{
	public class MainContext:DbContext
	{
		public MainContext(DbContextOptions<MainContext> o):base(o)
		{
		}
        public DbSet<FbUser> fb_users { get; set; }
        public DbSet<FbLocation> locations { get; set; }
        public DbSet<ContactInfo> contactInfos { get; set; }
        public DbSet<ContactAddress> contactAddresses { get; set; }
        public DbSet<MarketPlace> marketPlaces { get; set; }


        public DbSet<ScrapedUser> scraped_database { get; set; }
        public DbSet<ScrapedLocation> scraped_location { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScrapedUser>(s =>
            {
                s.HasMany(c => c.locations)
                .WithOne()
                .HasForeignKey(f => f.user);
            });
        }

    }
}

