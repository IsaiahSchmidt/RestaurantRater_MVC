using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantRater.Data;
using RestaurantRater.Models.RatingModels;

namespace RestaurantRater.Services.RatingServices
{
    public class RatingService : IRatingService
    {
        private readonly RestaurantDbContext _context;
        public RatingService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRating(RatingCreate model)
        {
            var entity = new Rating()
            {
                AtmosphereScore = model.AtmosphereScore,
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                RestaurantId = model.RestaurantId
            };
            entity.UserScore = Math.Round((model.AtmosphereScore + model.CleanlinessScore + model.FoodScore)/3, 2);
            await _context.Ratings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRating(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating is null) return false;
            _context.Remove(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> EditRating(RatingEdit model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RatingItem>> GetAllRatings()
        {
            IEnumerable<RatingItem> ratings = await _context.Ratings.Include(r => r.Restaurant).ThenInclude(x => x.Ratings)
            .Select(r => new RatingItem()
            {
                Id = r.Id,
                RestaurantName = r.Restaurant.Name,
                RestaurantId = r.Restaurant.Id,
                Score = r.Restaurant.Score
            }).ToListAsync();
            return ratings.DistinctBy(x => x.RestaurantName);
        }

        public async Task<RatingItem> GetRating(int id)
        {
            var rating = await _context.Ratings.Include(r => r.Restaurant).ThenInclude(x => x.Ratings).SingleOrDefaultAsync(x => x.Id == id);
            if (rating is null) return new RatingItem();
            return new RatingItem
            {
                Id = rating.Id,
                RestaurantName = rating.Restaurant.Name,
                RestaurantId = rating.Restaurant.Id,
                Score = rating.Restaurant.Score,
                AtmosphereScore = rating.AtmosphereScore,
                CleanlinessScore = rating.CleanlinessScore,
                FoodScore = rating.FoodScore
            };
        }

        public async Task<IEnumerable<RatingItem>> GetRatingsByRestaurantId(int restaurantId)
        {
            IEnumerable<RatingItem> ratings = await _context.Ratings.Where(r => r.Restaurant.Id == restaurantId)
                .Include(r => r.Restaurant).ThenInclude(x => x.Ratings).Select(r => new RatingItem
                {
                    Id = r.Id,
                    RestaurantId = r.Restaurant.Id,
                    RestaurantName = r.Restaurant.Name,
                    Score = r.Restaurant.Score,
                    AtmosphereScore = r.AtmosphereScore,
                    CleanlinessScore = r.CleanlinessScore,
                    FoodScore = r.FoodScore,
                    UserScore = r.UserScore
                }).ToListAsync();
            return ratings;
        }
    }
}