using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantRater.Data;
using RestaurantRater.Models.RatingModels;
using RestaurantRater.Models.RestaurantModels;

namespace RestaurantRater.Services
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<RestaurantListItem>> GetAllRestaurants()
        {
            List<RestaurantListItem> restaurants = await _context.Restaurants.Include(r => r.Ratings)
                .Select(r => new RestaurantListItem()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Score = r.Score
                }).ToListAsync();
            return restaurants;
        }

        public async Task<bool> CreateRestaurant(RestaurantCreate model)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = model.Name,
                Location = model.Location
            };
            _context.Restaurants.Add(restaurant);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<RestaurantDetail> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.Include(r => r.Ratings).FirstOrDefaultAsync(r => r.Id == id);

            RestaurantDetail restaurantDetail = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                Score = restaurant.Score,
                Ratings = restaurant.Ratings.Select(r => new RatingListItem{
                    Id = r.Id,
                    FoodScore = r.FoodScore,
                    AtmosphereScore = r.AtmosphereScore,
                    CleanlinessScore = r.CleanlinessScore
                }).ToList()
            };
            return restaurantDetail;
        }

        public async Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            var restaurantInDb = await _context.Restaurants.FindAsync(model.Id);
            if(restaurantInDb == null)
                return false;
            restaurantInDb.Name = model.Name;
            restaurantInDb.Location = model.Location;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaurantInDb = await _context.Restaurants.FindAsync(id);
            if(restaurantInDb == null)
                return false;
              _context.Restaurants.Remove(restaurantInDb);
             await _context.SaveChangesAsync();
             return true;
        }
    }
}