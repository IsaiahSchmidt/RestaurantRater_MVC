using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        // public double Score {get; set;}
        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        
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