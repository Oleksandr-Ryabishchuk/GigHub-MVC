﻿using System.ComponentModel.DataAnnotations;

namespace GigHub1.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
