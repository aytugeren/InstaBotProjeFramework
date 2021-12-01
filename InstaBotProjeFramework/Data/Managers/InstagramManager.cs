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
                        Description = item.Description
                    };
                    profilesDTO.Add(profile);
                }

            }

            return profilesDTO;
        }

        public bool AddInstagramProfile(InstagramProfileDTO profileDTO)
        {
            if (profileDTO != null)
            {
                profileDTO.Hashkey = Guid.NewGuid().ToString();
                var instagramProfile = new InstagramProfile
                {
                    Id = Guid.NewGuid(),
                    Description = profileDTO.Description,
                    Url = profileDTO.Url,
                    Username = profileDTO.Username,
                    UserId = profileDTO.UserId,
                    Status = StatusEnums.New.ToString(),
                    Password = this.GetHashedPassword(profileDTO.Password, profileDTO.Hashkey),
                    Hashkey = profileDTO.Hashkey,
                    CreatedDateTime = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                repoInstagram.Insert(instagramProfile);
                return true;
            }

            return false;
        }

        private string GetHashedPassword(string password, string hashKey)
        {
            SHA1 encrypt = new SHA1CryptoServiceProvider();
            var encrypted = encrypt.ComputeHash(Encoding.UTF8.GetBytes(password + hashKey));
            var sb = new StringBuilder(encrypted.Length * 2);
            foreach (byte b in encrypted)
            {
                sb.Append(b.ToString("x2"));
            }
            string encryptedPassword = sb.ToString();
            return encryptedPassword;
        }

    }
}