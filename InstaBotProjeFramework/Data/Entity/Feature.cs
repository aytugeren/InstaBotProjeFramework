using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Entity
{
    public class Feature : BaseEntity
    {
        public string FeatureName { get; set; }

        public string FeatureSP { get; set; }

        public string FeatureDescription { get; set; }

        public string FeatureTitle { get; set; }

        public decimal FeaturePoint { get; set; }

        public string FeatureSeoName { get; set; }

        public virtual ICollection<UserFeatures> Users { get; set; }

        public virtual ICollection<FollowBotInfo> FollowBotInfo { get; set; }
    }
}