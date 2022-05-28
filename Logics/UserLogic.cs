using DailyToolsAPI.DataLayer.UserDataLayer;
using DailyToolsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DailyToolsAPI.Logics
{
    public class UserLogic
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = new DailyToolsContext().Users.AsEnumerable();
            return users;
        }

        public static UserModel GetUserByUserName(string userName)
        {
            var user = new DailyToolsContext().Users.Where(user => user.UserName == userName)
                .Select(user => new UserModel
                {
                    UserName = user.UserName,
                    Address = user.Address,
                    Email = user.Email,
                    FullName = user.FullName,
                    Phone = user.Phone
                }).FirstOrDefault();

            return user;
        }

        public static UserModel GetUserByEmail(string email)
        {
            var user = new DailyToolsContext().Users.Where(user => user.Email == email)
                .Select(user => new UserModel
                {
                    UserName = user.UserName,
                    Address = user.Address,
                    Email = user.Email,
                    FullName = user.FullName,
                    Phone = user.Phone
                }).FirstOrDefault();

            return user;
        }

        public static LoginResponse GetUserByEmailAndPassword(LoginModel login)
        {
            var loginResponse = new LoginResponse();
            var user = new DailyToolsContext().Users.Where(user => user.UserName == login.UserName && user.Password == login.Password);

            if (user == null) return null;

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var tokenKey = Encoding.ASCII.GetBytes(config["JwtConfig:SecretKey"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            loginResponse = user.Select(user => new LoginResponse
            {
                Email = user.Email,
                Token = token
            }).FirstOrDefault();

            return loginResponse;
        }
    }
}
