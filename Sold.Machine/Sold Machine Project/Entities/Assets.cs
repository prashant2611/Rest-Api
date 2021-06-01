using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sold_Machine_Project.Entities
{
   
    public class Assets
    {
        [Key]
        public int id { get; set; }
        public string machineName { get; set; }
        [Required]
        [MaxLength(30)]
        public string assetName { get; set; }
        [Required]
        [MaxLength(10)]
        public string assetSeries { get; set; }
    }
}
