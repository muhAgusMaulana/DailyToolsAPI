using DailyToolsAPI.DataLayer;
using System;
using System.Collections.Generic;
using DailyToolsAPI.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DailyToolsAPI.Logics
{
    public class UserAccountLogic
    {
        public static IEnumerable<UserAccount> GetUserAccounts()
        {
            var userAccounts = new DailyToolsContext().UserAccounts.AsEnumerable();
            return userAccounts;
        }

        public static UserAccount GetUserAccount(Guid userAccountID)
        {
            var userAccount = new UserAccount();

            if (userAccountID != Guid.Empty)
            {
                userAccount = new DailyToolsContext().UserAccounts.Where(item => item.UserAccountId == userAccountID).FirstOrDefault();
            }
            
            return userAccount;
        }

        public static UserAccount GetUserAccount(string userName)
        {
            var userAccount = new UserAccount();

            if (string.IsNullOrEmpty(userName))
            {
                userAccount = new DailyToolsContext().UserAccounts.Where(item => item.UserName == userName).FirstOrDefault();
            }
            
            return userAccount;
        }

        public static void CreateUserAccount(NewUserAccountDataLayer model)
        {
            using (var context = new DailyToolsContext())
            {
                var userAccount = new UserAccount()
                {
                    UserAccountId = Guid.NewGuid(),
                    UserName = model.UserName,
                    AccountTypeCode = model.AccountTypeCode,
                    AmountBalance = 0,
                    IsActive = true,
                    InputTime = DateTime.Now,
                    InputUn = "agus.maulana",
                    ModifTime = DateTime.Now,
                    ModifUn = "agus.maulana"
                };

                context.UserAccounts.Add(userAccount);
                context.SaveChanges();
            }
        }

        public static void UpdateUserAccount(UserAccount model)
        {
            using (var context = new DailyToolsContext())
            {
                context.UserAccounts.Update(model);
                context.SaveChanges();
            }
        }

        public static void DeleteUserAccount(UserAccount model)
        {
            using (var context = new DailyToolsContext())
            {
                context.UserAccounts.Remove(model);
                context.SaveChanges();
            }
        }

    }
}
