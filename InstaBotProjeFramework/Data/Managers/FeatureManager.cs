using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Entity;
using InstaBotProjeFramework.Data.Enums;
using InstaBotProjeFramework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace InstaBotProjeFramework.Data.Managers
{
    public class FeatureManager
    {
        Repository<InstagramProfile> repoInstagramProfile = new Repository<InstagramProfile>();
        Repository<UserFeatures> repoUserFeature = new Repository<UserFeatures>();
        Repository<FollowBotInfo> repoFollowBotInfo = new Repository<FollowBotInfo>();

        public List<InstagramProfileDTO> GetFeatureOfUser(Guid id, Guid featureId)
        {
            var profiles = repoInstagramProfile.List().Where(x => x.UserId == id && x.IsActive && !x.IsDeleted && x.Status == StatusEnums.Published.ToString());
            var feature = repoUserFeature.List().Where(x => x.UserId == id && x.FeatureId == featureId).FirstOrDefault();
            var listOfInstagramProfiles = new List<InstagramProfileDTO>();
            if (profiles.Any())
            {
                foreach (var item in profiles)
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
                        LastWorkedTime = feature.LastWorkedTime ?? DateTime.MinValue,
                        LastWonFollowers = feature.LastWonFollowers ?? 0,
                        WorkedTimeCurrently = feature.WorkedTimeCurrently ?? DateTime.MinValue
                    });
                }

                return listOfInstagramProfiles;
            }

            return default(List<InstagramProfileDTO>);
        }

        public bool IsUsernameAvailable(string username, string profileId, string featureId)
        {
            bool resultOfSearch = false;
            Guid id = Guid.NewGuid();
            var isProfileRegistered = repoFollowBotInfo.List().Where(x => x.FeatureId == Guid.Parse(featureId) && x.InstagramProfileId == Guid.Parse(profileId) && x.WillFollowingAccountName == username);
            if (!isProfileRegistered.Any())
            {
                if (!string.IsNullOrEmpty(username) && !isProfileRegistered.Where(x => x.WillFollowingAccountName == username).Any())
                {
                    var model = new FollowBotInfo
                    {
                        Id = id,
                        FeatureId = Guid.Parse(featureId),
                        InstagramProfileId = Guid.Parse(profileId),
                        WillFollowingAccountName = username,
                        CreatedDateTime = DateTime.Now,
                        Status = StatusEnums.WaitingForApproval.ToString()
                    };

                    repoFollowBotInfo.Insert(model);
                }
            }

            Thread.Sleep(7000);

            var result = repoFollowBotInfo.List().Where(x => x.Id == id && x.Status == StatusEnums.Ready.ToString());
            if (result.Any())
            {
                resultOfSearch = true;
            }

            return resultOfSearch;
        }
    }
}