using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyToolsAPI.Logics
{
    public class AccountTypeLogic
    {
        public static IEnumerable<AccountType> GetAllAccountType()
        {
            var accountTypes = new DailyToolsContext().AccountTypes.AsEnumerable();
            return accountTypes;
        }

        public static AccountType GetAccountType(string accountTypeCode)
        {
            return new DailyToolsContext().AccountTypes.Where(x => x.AccountTypeCode == accountTypeCode).FirstOrDefault();
        }

        public static ResponseModel CreateAccountType(AccountTypeDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                using(var context = new DailyToolsContext())
                {
                    var accountType = new AccountType()
                    {
                        AccountTypeCode = model.AccountTypeCode,
                        AccountName = model.AccountName,
                        InputTime = DateTime.Now,
                        InputUn = "agus.maulana",
                        ModifTime = DateTime.Now,
                        ModifUn = "agus.maulana"
                    };

                    context.AccountTypes.Add(accountType);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public static ResponseModel UpdateAccountType(AccountTypeDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                using (var context = new DailyToolsContext())
                {
                    var accountType = GetAccountType(model.AccountTypeCode);
                    accountType.AccountName = model.AccountName;
                    accountType.ModifTime = DateTime.Now;
                    accountType.ModifUn = "agus.maulana";

                    context.AccountTypes.Update(accountType);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public static ResponseModel DeleteAccountType(string accountTypeCode)
        {
            var response = new ResponseModel();

            try
            {
                using (var context = new DailyToolsContext())
                {
                    var accountType = GetAccountType(accountTypeCode);

                    context.AccountTypes.Remove(accountType);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
    }
}
