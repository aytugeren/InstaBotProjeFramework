using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Entity;
using InstaBotProjeFramework.Data.Enums;
using InstaBotProjeFramework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Managers
{
    public class FeatureManager
    {
        Repository<InstagramProfile> repoInstagramProfile = new Repository<InstagramProfile>();
        Repository<UserFeatures> repoUserFeature = new Repository<UserFeatures>();

        public List<InstagramProfileDTO> GetFeatureOfUser(Guid id, Guid featureId)
        {
            var profiles = repoInstagramProfile.List().Where(x => x.UserId == id && x.IsActive && !x.IsDeleted && x.Status == StatusEnums.Published.ToString());
            var feature = repoUserFeature.List().Where(x => x.UserId == id && x.FeatureId == featureId).FirstOrDefault();
            var listOfInstagramProfiles = new List<InstagramProfileDTO>();
            if (profiles.Any())
            {
                foreach(var item in profiles)
                {
                    listOfInstagramProfiles.Add(new InstagramProfileDTO
                    {
                        Id = item.Id,
                        Url = item.Url,
                        Username = item.Username,
                        Followers = item.Followers,
                        Following = item.Following,
                        Description = item.Description,
                        UserId = item.UserId,
                        LastWorkedTime = feature.LastWorkedTime ?? DateTime.MinValue
                    });
                }

                return listOfInstagramProfiles;
            }

            return default(List<InstagramProfileDTO>);
        }
    }
}