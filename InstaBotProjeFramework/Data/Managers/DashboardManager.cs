using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Entity;
using InstaBotProjeFramework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Managers
{
    public class DashboardManager
    {
        UserManager userManager = new UserManager();
        Repository<UserFeatures> userFeatureRepo = new Repository<UserFeatures>();
        Repository<Feature> featureRepo = new Repository<Feature>();
        public UserDTO GetUserProfile(Guid id)
        {
            var user = userManager.GetUserById(id);
            return user;
        }

        public List<FeatureDTO> GetActiveBots(Guid id)
        {
            var featuresOfId = userFeatureRepo.List().Where(x => x.UserId == id).Select(x => x.FeatureId).ToList();
            var features = featureRepo.List().Where(x => featuresOfId.Contains(x.Id));

            List<FeatureDTO> listFeature = new List<FeatureDTO>();
            if (features.Any())
            {
                foreach(var item in features)
                {
                    listFeature.Add(new FeatureDTO
                    {
                        FeatureId = item.Id,
                        FeatureDescription = item.FeatureDescription,
                        FeatureName = item.FeatureName,
                        FeaturePoint = item.FeaturePoint,
                        FeatureSP = item.FeatureSP,
                        FeatureTitle = item.FeatureTitle,
                        FeatureSeoName = item.FeatureSeoName
                    });

                }

                return listFeature;
            }

            return default(List<FeatureDTO>);
        }

    }
}