using InstaBotProjeFramework.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DbContextFolder
{
    public class InstaBotContext : DbContext
    {
        public InstaBotContext() : base("InstaBotContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFeatures>().HasKey(x => new { x.UserId, x.FeatureId });
        }

        public DbSet<User> tblUser { get; set; }

        public DbSet<Feature> tblFeatures { get; set; }

        public DbSet<UserFeatures> tblUserFeatures { get; set; }

        public DbSet<InstagramProfile> tblInstagramProfile { get; set; }

        public DbSet<FollowBotInfo> tblFollowBotInfo { get; set; }
    }
}