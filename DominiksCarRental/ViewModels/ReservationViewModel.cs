using DominiksCarRental.DTOs;
using DominiksCarRental.Models;

namespace DominiksCarRental.ViewModels
{
    public class ReservationViewModel
    {
        public CarDTO carDTO { get; set; }
        public Reservation reservation { get; set; } = new Reservation();
    }
}
