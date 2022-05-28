using DailyToolsAPI.DataLayer.UserDataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Logics;
using DailyToolsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace DailyToolsAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Exception _exception;

        public UserController()
        {
            _exception = null;
        }

        [HttpGet("GetUsers")]
        public ResponseModel GetUsers()
        {
            var response = new ResponseModel();

            try
            {
                var users = UserLogic.GetUsers();

                if (users != null)
                {
                    response.ResponseCode = ResponseCode.SUCCESS;
                    response.Data = users;
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

        [HttpGet("GetUserByUserName/{userName}")]
        public ResponseModel GetUserByUserName(string userName)
        {
            var response = new ResponseModel();

            try
            {
                var user = UserLogic.GetUserByUserName(userName);
                if (user != null)
                {
                    response.ResponseCode = ResponseCode.SUCCESS;
                    response.Data = user;
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
                APILogLogic.CreateLog(controllerName, _exception, response, userName);
            }

            return response;
        }

        [HttpGet("GetUserByEmail/{email}")]
        public ResponseModel GetUserByEmail(string email)
        {
            var response = new ResponseModel();

            try
            {
                var user = UserLogic.GetUserByEmail(email);
                if (user != null)
                {
                    response.ResponseCode = ResponseCode.SUCCESS;
                    response.Data = user;
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
                APILogLogic.CreateLog(controllerName, _exception, response, email);
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("GetUserByLogin")]
        public ResponseModel GetUserByLogin([FromBody]LoginModel model)
        {
            var response = new ResponseModel();

            try
            {
                var user = UserLogic.GetUserByUserName(model.UserName);
                if (user == null)
                {
                    response.ResponseCode = ResponseCode.ERROR;
                    response.ResponseMessage = "Email tidak ditemukan";
                    return response;
                }

                var loginResponse = UserLogic.GetUserByEmailAndPassword(model);
                if (loginResponse != null)
                {
                    response.ResponseCode = ResponseCode.SUCCESS;
                    response.Data = loginResponse;
                }
                else
                {
                    response.ResponseCode = ResponseCode.ERROR;
                    response.ResponseMessage = "Password salah";
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
                APILogLogic.CreateLog(controllerName, _exception, response, model);
            }

            return response;
        }

    }
}
