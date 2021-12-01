using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Picture { get; set; }

        public bool IsAdmin { get; set; }

        public string Password { get; set; }

        public string HashKey { get; set; }

        public ICollection<Feature> Features { get; set; }

        public ICollection<InstagramProfile> InstagramProfiles { get; set; }
    }
}