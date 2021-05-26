using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Entities
{
    public class PointOfInterestEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        
        public int CityId { get; set; }
      
    }
}
