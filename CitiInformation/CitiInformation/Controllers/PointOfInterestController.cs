using AutoMapper;
using CitiInformation.Models;
using CitiInformation.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Controllers
{
    [ApiController]
    [Route("apii/cities/{CityId}/pointofinterest")]
    public class PointOfInterestController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityInfoRepository _cityInfoRepository;
        public PointOfInterestController(IMapper mapper,ICityInfoRepository cityInfoRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }


        [HttpGet]
        public IActionResult GetCity(int CityId)
        {
            var ReturnCity = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if(ReturnCity==null)
            {
                return NotFound("Result not found.");
            }

            return Ok(ReturnCity);
        }

        [HttpGet("{id}",Name ="GetPointOfInterest")]                       //Get method
        public IActionResult GetCityPointOfInterest(int CityId,int id)
        {
            var ReturnCity = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if (ReturnCity == null)
            {
                return NotFound("Result not found.");
            }

            var CityPointOfInterest = ReturnCity.pointOfInterst.FirstOrDefault(x=>x.Id==id);
            if(CityPointOfInterest==null)
            {
                return NotFound("Result not found.");
            }
            return Ok(CityPointOfInterest);

        }

      


        [HttpPost]                          //Create i.e. Post method
        public IActionResult CreatePointOfInterest(int CityId,[FromBody] PointOfInterestForCreationDetail CreatePointOfInterest)
        { 
            if(CreatePointOfInterest.Name==CreatePointOfInterest.Description)  //validation
            {
                ModelState.AddModelError("Description ","Description and Name should not be equal.");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var City = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if(City==null)
            {
                return NotFound("City not found.");
            }

            var MaxId = City.pointOfInterst.Max(x => x.Id);
            var FinalPointOfInterst = new PointOfInterest()
            {
                Id = ++MaxId,
                Name = CreatePointOfInterest.Name,
                Description = CreatePointOfInterest.Description
            };

            City.pointOfInterst.Add(FinalPointOfInterst);

            //return Ok(GetCityPointOfInterest(CityId,FinalPointOfInterst.Id));

            return CreatedAtRoute(
                "GetPointOfInterest",
                new {CityId,id=FinalPointOfInterst.Id},FinalPointOfInterst
                );
        }

        [HttpPut("{id}")]                                //Update 
        public IActionResult UpdatePointOfInterest(int CityId,int id,[FromBody] PointOfInterestForUpdateDetail PointOfInterest) //parameter name must be same as url 
        {
            if (PointOfInterest.Name == PointOfInterest.Description)  //validation
            {
                ModelState.AddModelError("Description ", "Description and Name should not be equal.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var City = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if(City==null)
            {
                return NotFound("Invalid input.");
            }

            var PointOfInterestFromStore = City.pointOfInterst.FirstOrDefault(x => x.Id == id);
            if(PointOfInterestFromStore==null)
            {
                return NotFound("Invalid Input");
            }

            PointOfInterestFromStore.Name = PointOfInterest.Name;
            PointOfInterestFromStore.Description = PointOfInterest.Description;

            return NoContent();
        }


        [HttpPatch("{id}")]         //Not working 

        public IActionResult PartialUpdatePointOfInterest(int CityId,int id,[FromBody] JsonPatchDocument<PointOfInterestForUpdateDetail> patchDoc)
        {
            var City = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if (City == null)
            {
                return NotFound("Invalid input.");
            }

            var PointOfInterestFromStore = City.pointOfInterst.FirstOrDefault(x => x.Id == id);
            if (PointOfInterestFromStore == null)
            {
                return NotFound("Invalid Input");
            }

            var PointOfInterestToPatch = new PointOfInterestForUpdateDetail()
            {
                Name = PointOfInterestFromStore.Name,
                Description = PointOfInterestFromStore.Description
            };

            patchDoc.ApplyTo(PointOfInterestToPatch);  //not able to add ModelState

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PointOfInterestFromStore.Name = PointOfInterestToPatch.Name;
            PointOfInterestFromStore.Description = PointOfInterestToPatch.Description;

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int CityId,int id)
        {
            var City = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == CityId);
            if (City == null)
            {
                return NotFound("Invalid input.");
            }

            var PointOfInterestFromStore = City.pointOfInterst.FirstOrDefault(x => x.Id == id);
            if (PointOfInterestFromStore == null)
            {
                return NotFound("Invalid Input");
            }

            City.pointOfInterst.Remove(PointOfInterestFromStore);
            return NoContent();
        }
        
    }
}
