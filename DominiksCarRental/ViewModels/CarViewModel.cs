using DominiksCarRental.DTOs;
using DominiksCarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DominiksCarRental.ViewModels
{
    public class CarViewModel
    {
        public CarDTO CarDTO { get; set; }
        public List<CarType> CarTypes { get; set; }
		public List<SelectListItem> CarTypeSelectListItems { get; set; }
	}
}
