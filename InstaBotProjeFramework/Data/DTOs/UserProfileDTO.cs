using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DTOs
{
    public class UserProfileDTO
    {
        public UserDTO User { get; set; }

        public UserStaticOfProfile UserStaticOfProfile { get; set; }
    }
}