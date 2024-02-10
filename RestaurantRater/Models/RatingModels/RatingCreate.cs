using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantRater.Models.RatingModels
{
    public class RatingCreate
    {
        [Display(Name = "Restaurant")]
        [Required]
        public int RestaurantId { get; set; }

        [Range(0, 10, ErrorMessage = "Please enter a value between 0 & 10")]
        [Required]
        public double FoodScore { get; set; }

        [Range(0, 10, ErrorMessage = "Please enter a value between 0 & 10")]
        [Required]
        public double AtmosphereScore { get; set; }

        [Range(0, 10, ErrorMessage = "Please enter a value between 0 & 10")]
        [Required]
        public double CleanlinessScore { get; set; }

        public IEnumerable<SelectListItem> RestaurantOptions {get; set;} = new List<SelectListItem>();
    }
}