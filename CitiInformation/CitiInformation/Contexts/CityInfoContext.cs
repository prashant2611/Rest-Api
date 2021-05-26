using CitiInformation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Contexts
{
    public class CityInfoContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterestEntity> PointOfInterest { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options):base(options)  //Another way using constructor
        {
            //Database.EnsureCreated();   //It checks that the DB is created or not, if not then it will be created otherwise it will ignore.
        }

        /*
        protected override void Onconfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConnectionString");
            base.OnConfiguring(optionsBuilder);
        }
        */
    }
}
