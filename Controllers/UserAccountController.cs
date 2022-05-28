using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Logics;
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

        [HttpGet("GetUserAccount")]
        public ResponseModel GetUserAccount()
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

        [HttpGet("GetUserAccountByUserName")]
        public ResponseModel GetUserAccountByUserName()
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

        [HttpGet("ViewMutation")]
        public ResponseModel ViewMutation()
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
        public ResponseModel CreateAccount()
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

        [HttpPost("DebitAccount")]
        public ResponseModel DebitAccount()
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

        [HttpPost("CreaditAccount")]
        public ResponseModel CreaditAccount()
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

        [HttpPost("DeleteAccount")]
        public ResponseModel DeleteAccount()
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

        [HttpGet("GetAllAccountType")]
        public ResponseModel GetAllAccountType()
        {
            var response = new ResponseModel();

            try
            {
                var accountTypes = AccountTypeLogic.GetAllAccountType()
                    .Select(item => new AccountTypeDataLayer 
                    { 
                        AccountTypeCode = item.AccountTypeCode,
                        AccountName = item.AccountName,
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
                        AccountName = accountType.AccountName
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
    }
}
