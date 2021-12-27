using InstaBotProjeFramework.Data.DbContextFolder;
using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Entity;
using InstaBotProjeFramework.Data.Enums;
using InstaBotProjeFramework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InstaBotProjeFramework.Data.Managers
{
    public class InstagramManager
    {
        Repository<InstagramProfile> repoInstagram = new Repository<InstagramProfile>();
        InstaBotContext instaBot = new InstaBotContext();

        public List<InstagramProfileDTO> GetInstagramProfilesByUserId(Guid id)
        {
            var profiles = instaBot.tblInstagramProfile.Where(x => x.UserId == id && x.IsActive && !x.IsDeleted).ToList();
            var profilesDTO = new List<InstagramProfileDTO>();
            if (profiles.Any())
            {
                foreach(var item in profiles)
                {
                    var profile = new InstagramProfileDTO
                    {
                        Username = item.Username,
                        Url = item.Url,
                        Description = item.Description,
                        Status = item.Status,
                        Followers = item.Followers,
                        Following = item.Following,
                        Id = item.Id
                    };
                    profilesDTO.Add(profile);
                }

            }

            return profilesDTO;
        }

        public InstagramProfile GetInstagramProfileInfoByUrl(string url)
        {
            var profile = repoInstagram.List().Where(x => x.Url == url).FirstOrDefault();
            if (profile != null)
            {
                return new InstagramProfile { 
                    Description = profile.Description,
                    Url = profile.Url,
                    Followers = profile.Followers,
                    Following = profile.Following,
                    Id = profile.Id,
                    Username = profile.Username
                };
            }

            return default(InstagramProfile);
        }

        public bool DeleteInstagramProfile(Guid id)
        {
            try
            {
                var instagramProfile = repoInstagram.GetById(id);

                repoInstagram.Delete(instagramProfile);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool AddInstagramProfile(InstagramProfileDTO profileDTO)
        {
            if (profileDTO != null)
            {
                var instagramProfile = new InstagramProfile
                {
                    Id = Guid.NewGuid(),
                    Description = profileDTO.Description,
                    Url = profileDTO.Url,
                    Username = profileDTO.Username,
                    UserId = profileDTO.UserId,
                    Status = StatusEnums.WaitingForApproval.ToString(),
                    Password = profileDTO.Password,
                    CreatedDateTime = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                repoInstagram.Insert(instagramProfile);
                return true;
            }

            return false;
        }

        public bool CheckUserNameOfUser(string username)
        {
            return repoInstagram.List().Where(x => x.Username == username).Any();
        }

        public bool CheckUserNameOfUrl(string url) 
        { 
            return repoInstagram.List().Where(x => x.Url == url).Any();
        }
    }
}