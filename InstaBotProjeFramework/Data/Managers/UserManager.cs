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
    public class UserManager
    {
        Repository<User> repoUser = new Repository<User>();
        
        public bool InsertUser(UserDTO user) { 
            if (user != null)
            {
                var isUserValid = repoUser.List().Where(x => x.Email == user.Email).Any();
                if (!isUserValid)
                {
                    var hashKey = Guid.NewGuid().ToString();
                    var userBase = new User()
                    {
                        Id = Guid.NewGuid(),
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        Password = this.GetHashedPassword(user.Password, hashKey),
                        HashKey = hashKey,
                        Age = user.Age,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDateTime = DateTime.Now,
                        IsAdmin = user.IsAdmin,
                        Username = user.Username,
                        Status = StatusEnums.New.ToString()
                    };

                    repoUser.Insert(userBase);
                }
                return true;
            }

            return false;
        }

        public UserDTO GetUserById(Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = repoUser.GetById(id);

                if (user != null)
                {
                    var userDTO = new UserDTO
                    {
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        Age = user.Age,
                        Id = user.Id,
                        Username = user.Username,
                        Picture = user.Picture
                    };

                    return userDTO;
                }
            }

            return default(UserDTO);
        }

        public UserStaticOfProfile GetUserStatistics(Guid id)
        {
            var user = repoUser.GetById(id);
            var userStatics = new UserStaticOfProfile
            {
                ProfileCount = user.InstagramProfiles.Where(x => x.IsActive && !x.IsDeleted).Count(),
                AccesibleProfileCount = user.InstagramProfiles.Where(x => x.Status == StatusEnums.Published.ToString()).Count(),
                GivenErrorProfileCount = user.InstagramProfiles.Where(x => x.Status == StatusEnums.Error.ToString()).Count(),
                FollowerCount = user.InstagramProfiles.Sum(x => x.Followers),
                FollowingCount = user.InstagramProfiles.Sum(x => x.Following),
                UsableBotCount = user.Features.Count()
            };
            return userStatics;
        }

        public bool UpdateUserPicture(string picture, Guid id)
        {
            if (!string.IsNullOrEmpty(picture) && id != Guid.Empty)
            {
                var user = repoUser.GetById(id);
                if (user != null)
                {
                    user.Picture = picture;
                    user.UpdatedDateTime = DateTime.Now;
                    repoUser.Update(user);
                    return true;
                }
            }
            return false;
        }

        public string CheckUserIsValid(LoginDTO loginInfo)
        {
            if (loginInfo != null)
            {
                var user = repoUser.List().Where(x => x.Email == loginInfo.Email).FirstOrDefault();
                if (user != null)
                {
                    var password = this.GetHashedPassword(loginInfo.Password, user.HashKey);
                    if (password == user.Password)
                    {
                        return user.Email + "|" + user.Id;
                    }
                }
            }

            return "";
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