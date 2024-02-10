using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRater.Data;

namespace RestaurantRater.Models.RatingModels
{
    public class RatingListItem
    {
        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }

        public int Id { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }
        public double Score { get; set; }

        // public List<Rating> Ratings = new List<Rating>();
        // public double AvgFoodScore
        // {
        //     get
        //     {
        //         return Ratings.Count > 0 ? Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count : 0;
        //     }
        // }
        // public double AvgCleanlinessScore
        // {
        //     get
        //     {
        //         return Ratings.Count > 0 ? Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count : 0;
        //     }
        // }
        // public double AvgAtmosphereScore
        // {
        //     get
        //     {
        //         return Ratings.Count > 0 ? Ratings.Select(r => r.AtmosphereScore).Sum() / Ratings.Count : 0;
        //     }
        // }
        // public double Score
        // {
        //     get
        //     {
        //         return (AvgFoodScore + AvgAtmosphereScore + AvgCleanlinessScore) / 3;
        //     }
        // }
    }
}