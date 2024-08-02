using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using DominiksCarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DominiksCarRental.Controllers
{
    [Authorize(Roles = "Admin, Owner, Customer Service Representative")]
    public class CarTypesController : Controller
	{
		private CarTypesService _carTypesService;

		public CarTypesController(CarTypesService carTypesService)
		{
			_carTypesService = carTypesService;
		}
		public IActionResult Index()
		{
			IEnumerable<CarTypeDTO> allCarTypes = _carTypesService.GetAllTypes();
			return View(allCarTypes);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateAsync(CarType carType)
		{
			await _carTypesService.AddCarTypeAsync(carType);
			return RedirectToAction("Create", "Cars");
		}
        public async Task<IActionResult> EditAsync(int id)
        {
            var carType = await _carTypesService.GetByIdAsync(id);
            if (carType == null)
            {
                return View("NotFound");
            }
            return View(carType);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(CarTypeDTO carTypeDTO, int id)
        {
            await _carTypesService.EditAsync(id, carTypeDTO);
            return RedirectToAction("Index");
        }
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var carTypeToDelete = await _carTypesService.GetByIdAsync(id);
			if (carTypeToDelete == null)
			{
				return View("NotFound");
			}
			await _carTypesService.DeleteCarTypeAsync(id);
			return RedirectToAction("Index");
		}
    }
}
