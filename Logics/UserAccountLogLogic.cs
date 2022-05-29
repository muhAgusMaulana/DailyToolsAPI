using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Models;
using System;
using System.Linq;

namespace DailyToolsAPI.Logics
{
    public class UserAccountLogLogic
    {
        public static UserAccountDataLayer CreateUserAccountLog(UserAccountTransactionDataLayer model)
        {
            var userAccountData = new UserAccountDataLayer();
            var transaction = new DailyToolsContext().Database.BeginTransaction();

            try
            {
                using (var context = new DailyToolsContext())
                {
                    var userAccount = context.UserAccounts.Where(item => item.UserName == model.UserName).FirstOrDefault();

                    decimal remainingBalance = userAccount.AmountBalance;

                    switch (model.OperationType)
                    {
                        case nameof(OperationTypeEnum.CRDT):
                            remainingBalance += model.Amount;
                            break;
                        case nameof(OperationTypeEnum.DEBT):
                            remainingBalance -= model.Amount;
                            break;
                        case nameof(OperationTypeEnum.TRFR):
                            break;
                        default:
                            throw new Exception($"{model.OperationType} does not registered in OperationTypeEnum");
                    }

                    userAccount.AmountBalance = remainingBalance;
                    userAccount.ModifTime = DateTime.Now;
                    userAccount.ModifUn = "agus.maulana";
                    context.UserAccounts.Update(userAccount);

                    var log = new UserAccountLog()
                    {
                        Amount = model.Amount,
                        OperationType = model.OperationType,
                        Remarks = model.Remarks,
                        UserAccountId = userAccount.UserAccountId,
                        InputUn = "agus.maulana",
                        ModifUn = "agus.maulana"
                    };

                    context.UserAccountLogs.Add(log);
                    context.SaveChanges();
                    transaction.Commit();

                    userAccount = context.UserAccounts.Where(item => item.UserName == model.UserName).FirstOrDefault();
                    userAccountData.UserName = userAccount.UserName;
                    userAccountData.UserAccountId = userAccount.UserAccountId;
                    userAccountData.AmountBalance = userAccount.AmountBalance;
                    userAccountData.FullName = UserLogic.GetUserByUserName(model.UserName).FullName;
                    userAccountData.AccountTypeName = AccountTypeLogic.GetAccountType(userAccount.AccountTypeCode).AccountTypeName;
                    userAccountData.IsActive = userAccount.IsActive;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }

            return userAccountData;
        }
    }
}
