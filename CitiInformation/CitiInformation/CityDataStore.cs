using CitiInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation
{
    public class CityDataStore
    {
        public static CityDataStore Current = new CityDataStore();
        public List<CityDetail> Cities;

        public CityDataStore()
        {
            Cities = new List<Models.CityDetail>()
        {
            new CityDetail()
            {
                Id=1,
                Name="Mumbai",
                Description="India's Largest city.",

                pointOfInterst=new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id=101,
                        Name="Dhayri",
                        Description="Populated Area."
                    },
                    new PointOfInterest()
                    {
                        Id=102,
                        Name="Bandra",
                        Description="Posh Area."
                    }
                }
            },
            new CityDetail()
            {
                Id=2,
                Name="Pune",
                Description="Home of Shivaji Maharaj.",

                pointOfInterst=new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id=101,
                        Name="Katraj",
                        Description="Outside Area."
                    },
                    new PointOfInterest()
                    {
                        Id=102,
                        Name="Shivaji Nagar",
                        Description="Main Area."
                    }
                }
            },
            new Models.CityDetail()
            {
                Id=3,
                Name="Banglore",
                Description="Biggest IT park in India.",

               pointOfInterst=new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id=101,
                        Name="ISRO",
                        Description="Biggest company."
                    },
                    new PointOfInterest()
                    {
                        Id=102,
                        Name="Google",
                        Description="Head office of India."
                    }
                }
            }
        };
        }
    }
}
