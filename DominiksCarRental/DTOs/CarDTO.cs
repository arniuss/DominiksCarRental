using DominiksCarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DominiksCarRental.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
        public string? MainImage { get; set; }
        public int? CarTypeID { get; set; }
        public CarType? CarType { get; set; }
		public int NumberOfSeats { get; set; }
        public string? Description { get; set; }
        public int RentalPrice { get; set; }
    }
}
