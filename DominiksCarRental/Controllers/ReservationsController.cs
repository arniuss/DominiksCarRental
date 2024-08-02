using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using DominiksCarRental.Services;
using DominiksCarRental.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DominiksCarRental.Controllers
{
    public class ReservationsController : Controller
    {
        private ReservationsService _reservationsService;
        private UserManager<AppUser> _userManager;

        public ReservationsController(ReservationsService reservationsService, UserManager<AppUser> userManager)
        {
            _reservationsService = reservationsService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index(int Id)
        {
            IEnumerable<Reservation> allReservations = await _reservationsService.GetAllReservations();
            return View(allReservations);
        }
        public async Task<IActionResult> Create(int Id)
        {
            var reservationViewModel = new ReservationViewModel();
            var carForReservation = await _reservationsService.GetCarByIdAsync(Id);
            if (carForReservation == null)
            {
                return RedirectToAction("NotFound");
            }
            reservationViewModel.carDTO = carForReservation;

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                reservationViewModel.reservation.Name = user.UserName;
                reservationViewModel.reservation.Email = user.Email;
                reservationViewModel.reservation.Phone = user.PhoneNumber;
            }
            return View(reservationViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _reservationsService.AddReservationAsync(model);
                return RedirectToAction("Index", "Cars");
            }
            return View("Error");
        }
        public async Task<IActionResult> EditAsync(int id)
        {
            var reservation = await _reservationsService.GetReservationByIdAsync(id);
            if(reservation == null)
            {
                return View("NotFound");
            }
            return View(reservation);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(Reservation reservation, int id)
        {
            await _reservationsService.EditAsync(id, reservation);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var reservationToDelete = await _reservationsService.GetReservationByIdAsync(id);
            if (reservationToDelete == null)
            {
                return View("NotFound");
            }
            await _reservationsService.DeleteCarTypeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
