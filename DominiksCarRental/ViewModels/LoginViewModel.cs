﻿using System.ComponentModel.DataAnnotations;

namespace DominiksCarRental.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? ReturnURL { get; set; }
        public bool RememberMe { get; set; }
    }
}
