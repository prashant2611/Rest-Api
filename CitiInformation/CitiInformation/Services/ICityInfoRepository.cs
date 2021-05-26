using CitiInformation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> Cities();

        City GetCity(int CityId);

        IEnumerable<PointOfInterestEntity> GetPointOfInterestEntities(int CityId);

        PointOfInterestEntity GetPointOfInterestForCity(int CityId, int PointOfInterestId);

        //bool CityExists(int CityId);
    }
}
