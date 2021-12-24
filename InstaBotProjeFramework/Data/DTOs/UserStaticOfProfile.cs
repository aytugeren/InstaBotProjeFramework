using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DTOs
{
    public class UserStaticOfProfile
    {
        public int ProfileCount { get; set; }

        public int FollowerCount { get; set; }

        public int FollowingCount { get; set; }

        public int UsableBotCount { get; set; }

        public int GivenErrorProfileCount { get; set; }

        public int AccesibleProfileCount { get; set; }
    }
}