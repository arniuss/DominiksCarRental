
using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using DominiksCarRental.Services;
using DominiksCarRental.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DominiksCarRental.Controllers
{
    public class CarsController : Controller
    {
        private CarsService _carsService;
        private ApplicationDbContext _applicationDbContext;

        public CarsController(CarsService carsService, ApplicationDbContext applicationDbContext)
        {
            _carsService = carsService;
			_applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<CarDTO> allCars = _carsService.GetAllCars();
            return View(allCars);
        }
        public async Task<IActionResult> Create()
        {
			var carTypes = await _applicationDbContext.CarTypes.ToListAsync();
			var carViewModel = new CarViewModel
			{
				CarDTO = new CarDTO(),
				CarTypes = carTypes,
				CarTypeSelectListItems = await _applicationDbContext.CarTypes
					.Select(ct => new SelectListItem
					{
						Value = ct.ID.ToString(),
						Text = ct.Name
					}).ToListAsync()
			};

			return View(carViewModel);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CarDTO carDTO)
        {

			if (ModelState.IsValid)
			{
				await _carsService.AddCarAsync(carDTO);
				return RedirectToAction("Index");
			}
            return View("Error");
		}
		public async Task<IActionResult> EditAsync(int id)
		{
			var carDTO = await _carsService.GetByIdAsync(id);
			if (carDTO == null)
			{
				return View("NotFound");
			}

			var carTypes = await _applicationDbContext.CarTypes.ToListAsync();

			var carViewModel = new CarViewModel
			{
				CarDTO = carDTO,
				CarTypes = carTypes,
				CarTypeSelectListItems = await _applicationDbContext.CarTypes
					.Select(ct => new SelectListItem
					{
						Value = ct.ID.ToString(),
						Text = ct.Name
					}).ToListAsync()
			};

			return View(carViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditAsync(int id, CarDTO carDTO)
		{
			if (ModelState.IsValid)
			{
				await _carsService.EditAsync(id, carDTO);
				return RedirectToAction("Index");
			}
	
			var carTypes = await _applicationDbContext.CarTypes.ToListAsync();
			var carViewModel = new CarViewModel
			{
				CarDTO = carDTO,
				CarTypes = carTypes,
				CarTypeSelectListItems = carTypes.Select(ct => new SelectListItem
				{
					Value = ct.ID.ToString(),
					Text = ct.Name
				}).ToList()
			};

			return View(carViewModel);
		}
		[HttpPost]
        public async Task<IActionResult> Rent(int id)
		{
			var car = await _carsService.GetByIdAsync(id);
			return RedirectToAction("Index", "Reservations");
		}

        [HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var carToDelete = await _carsService.GetByIdAsync(id);
			if (carToDelete == null)
			{
                return View("NotFound");
            }
			await _carsService.DeleteAsync(id);
			return RedirectToAction("Index");
		}

	}
}
