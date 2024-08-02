using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace DominiksCarRental.Services
{
	public class CarTypesService
	{
		public ApplicationDbContext _dbContext;

		public CarTypesService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddCarTypeAsync(CarType carType)
		{
			await _dbContext.CarTypes.AddAsync(carType);
			await _dbContext.SaveChangesAsync();
		}

        internal IEnumerable<CarTypeDTO> GetAllTypes()
        {
			var allCarTypes = _dbContext.CarTypes.ToList();
			var carTypesDTOs = new List<CarTypeDTO>();
			foreach (var carType in allCarTypes)
			{
				carTypesDTOs.Add(ModelToDTO(carType));
			}
			return carTypesDTOs;
        }

        private static CarTypeDTO ModelToDTO(CarType carType)
        {
			return new CarTypeDTO
			{
				ID = carType.ID,
				Name = carType.Name,
			};
        }
		private static CarType DTOToModel(CarTypeDTO carTypeDTO)
		{
			return new CarType
			{
				ID= carTypeDTO.ID,
				Name = carTypeDTO.Name,
			};
		}

        internal async Task<CarTypeDTO> GetByIdAsync(int id)
        {
			var carType = await VerifyExistence(id);
			return ModelToDTO(carType);
        }
        private async Task<CarType> VerifyExistence(int id)
        {
            var student = await _dbContext.CarTypes.FirstOrDefaultAsync(s => s.ID == id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        internal async Task EditAsync(int id, CarTypeDTO carTypeDTO)
        {
            _dbContext.CarTypes.Update(DTOToModel(carTypeDTO));
            await _dbContext.SaveChangesAsync();
        }

        internal async Task DeleteCarTypeAsync(int id)
        {
			var carTypeToDelete = await _dbContext.CarTypes.FirstOrDefaultAsync(carType => carType.ID == id);
			_dbContext.CarTypes.Remove(carTypeToDelete);
			await _dbContext.SaveChangesAsync();
        }
    }
}
