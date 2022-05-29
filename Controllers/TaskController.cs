using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Logics;
using DailyToolsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DailyToolsAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IConfiguration _config;
        private Exception _exception;
        public TaskController()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _exception = null;
        }

        [HttpPost("GetAllTask")]
        public ResponseModel GetAllTask()
        {
            var response = new ResponseModel();

            try
            {
                string datetimeFormat = _config["FormatConfig:Datetime"];

                var task = TaskLogic.GetAllTask()
                    .Where(task => task.IsActive == true)
                    .Select(task => new TaskDataLayer
                    {
                        TaskId = task.TaskId,
                        UserName = task.UserName,
                        IsActive = task.IsActive,
                        IsReminder = task.IsReminder,
                        TaskDateFromStr = task.TaskDateFrom.Value.ToString(datetimeFormat),
                        TaskDateToStr = task.TaskDateTo.Value.ToString(datetimeFormat),
                        TaskName = task.TaskName,
                        TaskPriorityCode = task.TaskPriorityCode
                    });

                response.Data = task;
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

        [HttpPost("GetTaskById")]
        public ResponseModel GetTaskById(Guid id)
        {
            var response = new ResponseModel();

            try
            {
                var taskById = TaskLogic.GetTaskById(id);
                if (taskById != null)
                {
                    var task = new TaskDataLayer()
                    {
                        TaskId = taskById.TaskId,
                        TaskName = taskById.TaskName,
                        IsActive = taskById.IsActive,
                        IsReminder = taskById.IsReminder,
                        TaskDateFromStr = taskById.TaskDateFrom.Value.ToString(),
                        TaskDateToStr = taskById.TaskDateTo.Value.ToString(),
                        TaskPriorityCode = taskById.TaskPriorityCode,
                        UserName = taskById.UserName
                    };

                    response.Data = task;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }
            finally
            {
                string controllerName = ControllerContext.RouteData.Values["action"].ToString();
                APILogLogic.CreateLog(controllerName, _exception, response, id);
            }

            return response;
        }

        [HttpPost("CreateTask")]
        public ResponseModel CreateTask([FromBody]TaskDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                TaskLogic.CreateTask(model);
            }
            catch (Exception ex)
            {
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

        [HttpPost("UpdateTask")]
        public ResponseModel UpdateTask([FromBody] TaskDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                TaskLogic.UpdateTask(model);
            }
            catch (Exception ex)
            {
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
