using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Models
{
    public class InstagramProfileModel
    {
        [Required(ErrorMessage ="It must be filled!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "It must be filled!")]
        public string Url { get; set; }

        public string Description { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "It must be filled!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public Guid UserId { get; set; }
    }
}