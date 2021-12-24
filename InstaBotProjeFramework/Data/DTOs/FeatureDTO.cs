using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DTOs
{
    public class FeatureDTO
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }

        public string FeatureSP { get; set; }

        public string FeatureDescription { get; set; }

        public string FeatureTitle { get; set; }

        public decimal FeaturePoint { get; set; }

        public string FeatureSeoName { get; set; }
    }
}