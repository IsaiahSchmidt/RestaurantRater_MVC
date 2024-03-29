using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models.RestaurantModels
{
    public class RestaurantCreate
    {
        [Required]
        [StringLength(100)]
        public string Name {get; set;}
        
        [Required]
        [StringLength(100)]
        public string Location {get; set;}
    }
}