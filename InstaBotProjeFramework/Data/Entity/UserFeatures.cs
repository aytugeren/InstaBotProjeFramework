using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Entity
{
    public class UserFeatures
    {
        public Guid UserId { get; set; }

        public Guid FeatureId { get; set; }

        public DateTime? LastWorkedTime { get; set; }

        public User User { get; set; }

        public Feature Feature { get; set; }
    }
}