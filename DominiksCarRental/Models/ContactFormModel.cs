﻿using System.ComponentModel.DataAnnotations;

namespace DominiksCarRental.Models
{
    public class ContactFormModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}

