
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominiksCarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MainImage { get; set; }
		public int? CarTypeID { get; set; }

		[ForeignKey("CarTypeID")]
		public CarType? CarType { get; set; }
		public int NumberOfSeats { get; set; }
        public string? Description { get; set; }
        public int RentalPrice { get; set; }
    }
}
