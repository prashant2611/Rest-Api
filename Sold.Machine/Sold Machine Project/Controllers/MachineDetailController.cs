using Microsoft.AspNetCore.Mvc;
using Sold_Machine_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sold_Machine_Project.Controllers
{
    [ApiController]
    [Route("api.soldmachine.com")]
    public class MachineDetailController:ControllerBase
    {
        private readonly IMachineDetailRepository _machineDetailRepository;

        public MachineDetailController(IMachineDetailRepository machinesInfoRepository)
        {
            _machineDetailRepository = machinesInfoRepository?? throw new ArgumentNullException(nameof(machinesInfoRepository));
        }


        [HttpGet("machinetype-assets/{machineType}")]
        public IActionResult GetAssetForMachineType(string machineType)
        {
            var assetList = _machineDetailRepository.GetAssetForMachineType(machineType);
            if(assetList==null)
            {
                return NotFound("Result not found.");
            }

            return Ok(assetList);
        }

        [HttpGet("asset-machines/{assetName}")]
        public IActionResult GetMachineTypeForAsset(string assetName)
        {
            var machineList = _machineDetailRepository.GetMachineTypeForAsset(assetName);
            if(machineList==null)
            {
                return NotFound("Result not found.");
            }
            return Ok(machineList);
        }

        [HttpGet("machines-use-letestasset")]
        public IActionResult GetMachineTypeUseLetestAsset()
        {
            var letestSeries = _machineDetailRepository.GetMachineTypeUseLetestAsset();
            if(letestSeries==null)
            {
                return NotFound("Result not found.");
            }
            return Ok(letestSeries);
        }
    }
}
