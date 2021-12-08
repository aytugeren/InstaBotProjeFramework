using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DTOs
{
    public class InstagramProfileDTO
    {
        public string Username { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Status { get; set; }

        public string Hashkey { get; set; }

        public Guid UserId { get; set; }
    }
}