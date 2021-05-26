using CitiInformation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CitiInformation.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<PointOfInterestEntity> pointOfInterst { set; get; } = new List<PointOfInterestEntity>();
    }
}
