using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantRater.Models.RatingModels
{
    public class RatingEdit
    {
        [Required]
        public int Id {get; set;}
        
        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId {get; set;}

        [Required]
        [Range(0,10,ErrorMessage = "Please enter a value between 0 & 10")]
        public double Score {get; set;}
    }
}