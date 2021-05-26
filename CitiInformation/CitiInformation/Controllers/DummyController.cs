using CitiInformation.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController: ControllerBase
    {
       private CityInfoContext _cix;
        public DummyController(CityInfoContext cix)
        {
            _cix = cix ?? throw new ArgumentNullException(nameof(cix));
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
