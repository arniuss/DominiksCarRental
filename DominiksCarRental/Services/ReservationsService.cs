using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using DominiksCarRental.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DominiksCarRental.Services
{
    public class ReservationsService
    {
        private ApplicationDbContext _applicationDbContext;
        private UserManager<AppUser> _userManager;

        public ReservationsService(ApplicationDbContext applicationDbContext, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }
        internal async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            var allReservations = await _applicationDbContext.Reservations.ToListAsync();
            return allReservations;
        }

        public async Task<CarDTO> GetCarByIdAsync(int carId)
        {
            Car car = await VerifyExistence(carId);           
            return ModelToDTO(car);
        }
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            Reservation reservation = await _applicationDbContext.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);
            return reservation;
        }
        public async Task AddReservationAsync(ReservationViewModel reservation)
        {
            await _applicationDbContext.Reservations.AddAsync(NewReservation(reservation));
            await _applicationDbContext.SaveChangesAsync();
        }
        internal async Task EditAsync(int id, Reservation reservation)
        {
            _applicationDbContext.Reservations.Update(reservation);
            await _applicationDbContext.SaveChangesAsync();
        }
        private async Task<Car> VerifyExistence(int id)
        {
            var car = await _applicationDbContext.Cars.FirstOrDefaultAsync(s => s.Id == id);
            return car;
        }
        private Reservation NewReservation(ReservationViewModel model)
        {
            return new Reservation
            {
                Id = model.reservation.Id,
                CarId = model.carDTO.Id,
                Name = model.reservation.Name,
                CarName = model.carDTO.Name,
                Phone = model.reservation.Phone,
                Email = model.reservation.Email,
                Message = model.reservation.Message,
                StartDate = model.reservation.StartDate,
                EndDate = model.reservation.EndDate
            };
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

        internal async Task DeleteCarTypeAsync(int id)
        {
            var reservationToDelete = await _applicationDbContext.Reservations.FirstOrDefaultAsync(reservation => reservation.Id == id);
            _applicationDbContext.Reservations.Remove(reservationToDelete);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
