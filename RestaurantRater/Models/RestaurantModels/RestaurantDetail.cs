using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRater.Models.RatingModels;

namespace RestaurantRater.Models.RestaurantModels
{
    public class RestaurantDetail
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Location {get; set;}
        [Display(Name = "Average Score")]
        public double Score {get; set;}

        public List<RatingListItem> Ratings { get; set; } = new();
    }
}