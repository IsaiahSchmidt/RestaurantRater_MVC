using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRater.Models.RatingModels;

namespace RestaurantRater.Services.RatingServices
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingItem>> GetAllRatings();
        Task<RatingItem> GetRating(int id);
        Task<IEnumerable<RatingItem>>GetRatingsByRestaurantId(int restaurantId);
        Task<bool> CreateRating(RatingCreate model);
        Task<bool> EditRating(RatingEdit model);
        Task<bool> DeleteRating(int id);
    }//gtg
}