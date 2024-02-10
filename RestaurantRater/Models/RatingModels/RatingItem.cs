using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models.RatingModels
{
    public class RatingItem
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }

        [Display(Name = "Rating")]
        public double Score { get; set; }

        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }
        public double UserScore { get; set; }
    }
}