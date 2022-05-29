using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Logics;
using DailyToolsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DailyToolsAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private Exception _exception;
        public UserAccountController()
        {
            _exception = null;
        }

        #region UserAccount Endpoint
        [HttpGet("GetUserAccountList")]
        public ResponseModel GetUserAccountList()
        {
            var response = new ResponseModel();

            try
            {
                var userAccounts = UserAccountLogic.GetUserAccounts();
                var users = UserLogic.GetUsers();
                var accountType = AccountTypeLogic.GetAccountTypes();
                var result = (from account in userAccounts
                              join type in accountType on account.AccountTypeCode equals type.AccountTypeCode
                              join user in users on account.UserName equals user.UserName
                              select new UserAccountDataLayer()
                              {
                                  UserAccountId = account.UserAccountId,
                                  AccountTypeName = type.AccountTypeName,
                                  AmountBalance = account.AmountBalance,
                                  IsActive = account.IsActive,
                                  FullName = user.FullName,
                                  UserName = account.UserName
                              }).ToList();

                response.Data = result;
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpGet("GetUserAccountByUserName")]
        public ResponseModel GetUserAccountByUserName(string userName)
        {
            var response = new ResponseModel();

            try
            {
                var userAccounts = UserAccountLogic.GetUserAccounts();
                var users = UserLogic.GetUsers();
                var accountType = AccountTypeLogic.GetAccountTypes();
                var result = (from account in userAccounts
                              join type in accountType on account.AccountTypeCode equals type.AccountTypeCode
                              join user in users on account.UserName equals user.UserName
                              where account.UserName.ToLower() == userName.ToLower()
                              select new UserAccountDataLayer()
                              {
                                  UserAccountId = account.UserAccountId,
                                  AccountTypeName = type.AccountTypeName,
                                  AmountBalance = account.AmountBalance,
                                  IsActive = account.IsActive,
                                  FullName = user.FullName,
                                  UserName = account.UserName
                              }).ToList();

                response.Data = result;
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpPost("ViewMutation")]
        public ResponseModel ViewMutation([FromBody]UserAccountLogDataLayer model)
        {
            var response = new ResponseModel();

            try
            {

            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpPost("CreateAccount")]
        public ResponseModel CreateAccount([FromBody]NewUserAccountDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                if (model != null)
                {
                    UserAccountLogic.CreateUserAccount(model);
                }
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpPost("UserAccountTransaction")]
        public ResponseModel UserAccountTransaction([FromBody]UserAccountTransactionDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                var userAccount = UserAccountLogLogic.CreateUserAccountLog(model);
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpPost("DeleteAccount")]
        public ResponseModel DeleteAccount([FromBody]UserAccount model)
        {
            var response = new ResponseModel();

            try
            {
                if (model != null)
                {
                    UserAccountLogic.DeleteUserAccount(model);
                }
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }
        #endregion

        #region AccountType Endpoint
        [HttpGet("GetAllAccountType")]
        public ResponseModel GetAllAccountType()
        {
            var response = new ResponseModel();

            try
            {
                var accountTypes = AccountTypeLogic.GetAccountTypes()
                    .Select(item => new AccountTypeDataLayer 
                    { 
                        AccountTypeCode = item.AccountTypeCode,
                        AccountTypeName = item.AccountTypeName,
                    });

                response.Data = accountTypes;
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response);
            }

            return response;
        }

        [HttpGet("GetAccountType")]
        public ResponseModel GetAccountType(string accountTypeCode)
        {
            var response = new ResponseModel();

            try
            {
                var accountType = AccountTypeLogic.GetAccountType(accountTypeCode);
                
                if (accountType != null)
                {
                    var accountTypeDataLayer = new AccountTypeDataLayer()
                    {
                        AccountTypeCode = accountType.AccountTypeCode,
                        AccountTypeName = accountType.AccountTypeName
                    };

                    response.Data = accountTypeDataLayer;
                }
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response, accountTypeCode);
            }

            return response;
        }

        [HttpPost("CreateAccountType")]
        public ResponseModel CreateAccountType([FromBody]AccountTypeDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                response = AccountTypeLogic.CreateAccountType(model);
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response, model);
            }

            return response;
        }

        [HttpPost("UpdateAccountType")]
        public ResponseModel UpdateAccountType([FromBody]AccountTypeDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                response = AccountTypeLogic.UpdateAccountType(model);
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response, model);
            }

            return response;
        }

        [HttpPost("DeleteAccountType")]
        public ResponseModel DeleteAccountType([FromBody]string accountTypeCode)
        {
            var response = new ResponseModel();

            try
            {
                response = AccountTypeLogic.DeleteAccountType(accountTypeCode);
            }
            catch (Exception ex)
            {
                _exception = ex;
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response, accountTypeCode);
            }

            return response;
        }
        #endregion
    }
}
