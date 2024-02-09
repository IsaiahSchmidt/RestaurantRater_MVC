using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantRater.Data;
using RestaurantRater.Models.RestaurantModels;
using RestaurantRater.Services;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        private IRestaurantService _service;

        public RestaurantController(IRestaurantService service, ILogger<RestaurantController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();
            return View(restaurants);
        }

        [ActionName("Details")]
        public async Task<IActionResult> Restaurant(int id)
        {
            RestaurantDetail restaurant = await _service.GetRestaurantById(id);
            if (restaurant == null)
                return RedirectToAction(nameof(Index));
            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateRestaurant(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var restaurant = await _service.GetRestaurantById(id);
            RestaurantEdit restaurantEdit = new RestaurantEdit
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
            return View(restaurantEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RestaurantEdit model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var restaurant = await _service.UpdateRestaurant(model);
            if (restaurant == null)
                return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _service.GetRestaurantById(id);
            if(restaurant is null)
                return RedirectToAction(nameof(Index));
            RestaurantDetail restaurantDetail = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
            return View(restaurantDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, RestaurantDetail model)
        {
            var restaurant = await _service.DeleteRestaurant(model.Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}