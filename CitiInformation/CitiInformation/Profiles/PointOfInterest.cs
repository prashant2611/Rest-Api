using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Profiles
{
    public class PointOfInterest:Profile
    {
        public PointOfInterest()
        {
            CreateMap<Models.PointOfInterestForCreationDetail, Entities.PointOfInterestEntity>();
        }
    }
}
