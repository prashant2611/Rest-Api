using CitiInformation.Contexts;
using CitiInformation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IEnumerable<City> Cities()
        {
            return _context.Cities.OrderBy(x => x.Name).ToList();
        }

        

        public City GetCity(int CityId)
        {
            return _context.Cities.Where(x => x.Id == CityId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterestEntity> GetPointOfInterestEntities(int CityId)
        {
            return _context.PointOfInterest.Where(x => x.CityId == CityId);
        }

        public PointOfInterestEntity GetPointOfInterestForCity(int CityId, int PointOfInterestId)
        {
            return _context.PointOfInterest.Where(x => x.CityId == CityId && x.Id==PointOfInterestId).FirstOrDefault();
        }
    }
}
