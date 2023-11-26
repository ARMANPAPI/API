    using CityInfo.API.Entiteis;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoDbContext : DbContext
    {
        public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterset> PointsOfInterset { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region SeedData

            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Lorstan",
                    Description = "SHAHRESTAN",
                }, new City()
                {
                    Id = 2,
                    Name = "Tehran",
                    Description = "shemirn",
                }, new City()
                {
                    Id = 3,
                    Name = "esfahan",
                    Description = "33poleh",
                });

            //--------------------------------

            modelBuilder.Entity<PointOfInterset>().
                HasData(
                new PointOfInterset()
                {
                    CityId = 1,
                    Id = 1,
                    Name = "BISHE",
                    Description = "sarsabsz"
                }, new PointOfInterset()
                {
                    CityId = 1,
                    Id = 2,
                    Name = "test2",
                    Description = "test2"
                }, new PointOfInterset()
                {
                    CityId = 2,
                    Id = 3,
                    Name = "test3",
                    Description = "test3"
                }, new PointOfInterset()
                {
                    CityId = 2,
                    Id = 4,
                    Name = "test4",
                    Description = "test4"
                }, new PointOfInterset()
                {
                    CityId = 3,
                    Id = 5,
                    Name = "test5",
                    Description = "test5"
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
