﻿using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Modules.MUser
{
    public class UserService : CommonService, IUserService
    {
        private IJWTHandler JWTHandler;
        public UserService(IJWTHandler JWTHandler) : base()
        {
            this.JWTHandler = JWTHandler;
        }
        public long Count(SearchUserEntity SearchUserEntity)
        {
            if (SearchUserEntity == null) SearchUserEntity = new SearchUserEntity();
            IQueryable<User> Users = IMSContext.Users;
            Users = SearchUserEntity.ApplyTo(Users);
            return Users.Count();
        }
        public List<UserEntity> Get(SearchUserEntity SearchUserEntity)
        {
            if (SearchUserEntity == null) SearchUserEntity = new SearchUserEntity();
            IQueryable<User> Users = IMSContext.Users
                .Include(u => u.Admin)
                .Include(u => u.Student)
                .Include(u => u.Lecturer)
                .Include(u => u.HrEmployee);
            Users = SearchUserEntity.ApplyTo(Users);
            Users = SearchUserEntity.SkipAndTake(Users);
            return Users.ToList().Select(u => new UserEntity(u)).ToList();
        }


        public UserEntity Get(Guid UserId)
        {
            User User =  IMSContext.Users
                .Include(u => u.Admin)
                .Include(u => u.Student)
                .Include(u => u.Lecturer)
                .Include(u => u.HrEmployee)
                .Where(u => u.Id == UserId).FirstOrDefault();
            if (User == null)
                throw new BadRequestException("User không tồn tại");
            return new UserEntity(User);
        }

        public UserEntity Create(UserEntity UserEntity)
        {
            if (string.IsNullOrEmpty(UserEntity.Username))
                throw new BadRequestException("Bạn chưa điền Username");
            if (string.IsNullOrEmpty(UserEntity.Password))
                throw new BadRequestException("Bạn chưa điền Password");
            User User = IMSContext.Users.Where(u => u.Username.ToLower().Equals(UserEntity.Username.ToLower())).FirstOrDefault();
            if (User == null)
            {
                User = new User();
                User.Id = Guid.NewGuid();
                User.Username = UserEntity.Username;

                IMSContext.Users.Add(User);
            }
            User.Password = GetHashString(UserEntity.Password);
            IMSContext.SaveChanges();
            UserEntity.Id = User.Id;
            UserEntity.Password = User.Password;
            return UserEntity;

        }
        public bool ChangePassword(Guid userId, PasswordEntity passwordEntity)
        {
            string oldPassword = GetHashString(passwordEntity.OldPassword);
            User User = IMSContext.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
            if (User == null) return false;
            if (oldPassword.Equals(User.Password))
            {
                passwordEntity.UserEntity.ToModel(User);
                User.Password = GetHashString(passwordEntity.UserEntity.Password);
                IMSContext.SaveChanges();
                return true;
            }
            return false;
        }
        public UserEntity Update(Guid UserId, UserEntity UserEntity)
        {
            User User = IMSContext.Users.Where(u => u.Id.Equals(UserEntity.Id)).FirstOrDefault();
            if (User == null)
                throw new BadRequestException("User không tồn tại.");
            UserEntity.ToModel(User);
            User.Password = GetHashString(UserEntity.Password);
            IMSContext.SaveChanges();
            return new UserEntity(User);
        }
        public bool Delete(Guid UserId)
        {
            User User = IMSContext.Users.Where(u => u.Id == UserId).FirstOrDefault();
            if (User == null)
                throw new BadRequestException("User không tồn tại.");
            IMSContext.Users.Remove(User);
            IMSContext.SaveChanges();
            return true;
        }

        public string Login(UserEntity UserEntity)
        {
            if (string.IsNullOrEmpty(UserEntity.Username))
                throw new BadRequestException("Bạn chưa điền Username");
            if (string.IsNullOrEmpty(UserEntity.Password))
                throw new BadRequestException("Bạn chưa điền Password");

            User User = IMSContext.Users
               .Include(u => u.Admin)
               .Include(u => u.Student)
               .Include(u => u.Lecturer)
               .Include(u => u.HrEmployee)
               .Where(u => u.Username.ToLower().Equals(UserEntity.Username.ToLower())).FirstOrDefault();

            if (User == null)
                throw new BadRequestException("User không tồn tại.");
            string hashPassword = GetHashString(UserEntity.Password);
            if (!User.Password.Equals(hashPassword))
                throw new BadRequestException("Bạn nhập sai password.");
            UserEntity = new UserEntity(User);
            return JWTHandler.CreateToken(UserEntity);
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            HashAlgorithm algorithm = SHA256.Create();
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
