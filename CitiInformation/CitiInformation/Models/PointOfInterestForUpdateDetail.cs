using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Models
{
    public class PointOfInterestForUpdateDetail
    {
        [Required(ErrorMessage = "You should provide name.")]        //validation through annotation
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }
    }
}
