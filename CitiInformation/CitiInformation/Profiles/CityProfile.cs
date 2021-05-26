using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Profiles
{
    public class CityProfile:Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, Models.CityWithoutPointOfInterest>();
        }
    }
}
