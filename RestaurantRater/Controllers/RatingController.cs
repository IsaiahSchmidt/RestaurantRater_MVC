using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantRater.Data;
using RestaurantRater.Models.RatingModels;
using RestaurantRater.Services;
using RestaurantRater.Services.RatingServices;

namespace RestaurantRater.Controllers
{
    public class RatingController : Controller
    {
        private readonly ILogger<RatingController> _logger;
        private IRatingService _service;
        private IRestaurantService _restaurantService;
        public RatingController(IRatingService service,IRestaurantService restaurantService, ILogger<RatingController> logger)
        {
            _logger = logger;
            _service = service;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ratings = await _service.GetAllRatings();
            return View(ratings);
        }

        [HttpGet]
        public async Task<IActionResult> RatingsByRestaurant(int id)
        {
            var restaurants = await _service.GetRatingsByRestaurantId(id);
            if(restaurants == null) return RedirectToAction("Index");
            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> restaurantOptions = _restaurantService.GetAllRestaurants()
                .Result.Select(r=> new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString(),
                }).ToList();
            RatingCreate model = new RatingCreate();
            model.RestaurantOptions = restaurantOptions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreate model)
        {
            if(!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            if(await _service.CreateRating(model)) return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var rating = await _service.GetRating(id.Value);
            if(rating == null) return RedirectToAction(nameof(Index));

            return View(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _service.DeleteRating(id)) return RedirectToAction(nameof(Index));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}