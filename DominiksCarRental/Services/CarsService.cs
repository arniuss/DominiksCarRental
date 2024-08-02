using Microsoft.EntityFrameworkCore;
using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DominiksCarRental.ViewModels;

namespace DominiksCarRental.Services
{
    public class CarsService
    {
        private ApplicationDbContext _context;

        public CarsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarDTO> GetAllCars()
        {
			var allCars = _context.Cars.Include(c => c.CarType).ToList();
			var carsDTOs = new List<CarDTO>();
			foreach (var car in allCars)
			{
				var carDTO = ModelToDTO(car);
				carDTO.CarTypeID = car.CarTypeID;
				carsDTOs.Add(carDTO);
			}
			return carsDTOs;
		}


		public async Task<CarViewModel> GetCarViewModelAsync()
		{
			var carTypes = await _context.CarTypes.Select(ct => new SelectListItem
			{
				Value = ct.ID.ToString(),
				Text = ct.Name
			}).ToListAsync();

			var carViewModel = new CarViewModel
			{
				CarDTO = new CarDTO(),
				CarTypeSelectListItems = carTypes
			};

			return carViewModel;
		}
		public async Task<CarDTO> GetByIdAsync(int carId)
        {
            Car carToShow = await VerifyExistence(carId);
            return ModelToDTO(carToShow);
        }
		private async Task<Car> VerifyExistence(int id)
		{
			var car = await _context.Cars.FirstOrDefaultAsync(s => s.Id == id);
			if (car == null)
			{
				return null;
			}
			return car;
        }
		public async Task AddCarAsync(CarDTO carDTO)
		{
            await _context.Cars.AddAsync(DTOToModel(carDTO));
			await _context.SaveChangesAsync();
		}
		public async Task EditAsync(int id, CarDTO carDTO)
		{
			var carToUpdate = await _context.Cars.FindAsync(id);
			if (carToUpdate != null)
			{
				carToUpdate.Name = carDTO.Name;
				carToUpdate.MainImage = carDTO.MainImage;
				carToUpdate.CarTypeID = carDTO.CarTypeID;
				carToUpdate.CarType = carDTO.CarType;
				carToUpdate.NumberOfSeats = carDTO.NumberOfSeats;
				carToUpdate.Description = carDTO.Description;
				carToUpdate.RentalPrice = carDTO.RentalPrice;

				await _context.SaveChangesAsync();
			}
		}
		private static CarDTO ModelToDTO(Car car)
		{
			return new CarDTO
			{
				Id = car.Id,
				Name = car.Name,
				MainImage = car.MainImage,
				CarTypeID = car.CarTypeID,
				CarType = car.CarType,				
				NumberOfSeats = car.NumberOfSeats,
				Description = car.Description,
				RentalPrice = car.RentalPrice
			};
		}
		private Car DTOToModel(CarDTO carDTO)
		{
			return new Car
			{
				Id = carDTO.Id,
				Name = carDTO.Name,
				MainImage = carDTO.MainImage,
				CarTypeID = carDTO.CarTypeID,
				CarType = carDTO.CarType,
				NumberOfSeats = carDTO.NumberOfSeats,
				Description = carDTO.Description,
				RentalPrice = carDTO.RentalPrice
			};
		}

        internal async Task DeleteAsync(int id)
        {
            var carToDelete = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
			_context.Cars.Remove(carToDelete);
			await _context.SaveChangesAsync();
        }
    }
}
