using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Entity
{
    public class FollowBotInfo
    {
        public Guid Id { get; set; }

        public Guid FeatureId { get; set; }

        public string WillFollowingAccountName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime WorkedTimeCurrently { get; set; }
        public Guid InstagramProfileId { get; set; }
        public string Status { get; set; }

        public Feature Feature { get; set; }

        public InstagramProfile InstagramProfile { get; set; }
    }
}