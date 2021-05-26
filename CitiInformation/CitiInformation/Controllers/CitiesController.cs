using AutoMapper;
using CitiInformation.Models;
using CitiInformation.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Controllers
{
    [ApiController]
    [Route("api/cities")]                            //general
    public class CitiesController: ControllerBase
    { 
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

       public CitiesController(ICityInfoRepository cityRepository, IMapper mapper)
        {
            _cityInfoRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]                                    //specify which http protocol we use
        public IActionResult GetCities()
        {
            /*return new JsonResult(
                new List<object>()
                {
                    new {id=1,Name="Mumbai"},
                    new {id=2,Name="Pune"}
                });*/

            // return new JsonResult(CityDataStore.Current.Cities);

            var CityEntities = _cityInfoRepository.Cities();

            /*   //Without mapper
            List<CityWithoutPointOfInterest> results = new List<CityWithoutPointOfInterest>();

            foreach(var City in CityEntities)
            {
                results.Add(new CityWithoutPointOfInterest()
                {
                    Id=City.Id,
                    Name=City.Name,
                    Description=City.Description
                });
            }
            return Ok(results);
            */

            //withmapper

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterest>>(CityEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
             var ReturnCity= CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);
            
            if(ReturnCity==null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(ReturnCity);
        }
    }
}
