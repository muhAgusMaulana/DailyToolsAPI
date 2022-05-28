using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyToolsAPI.Logics
{
    public class TaskLogic
    {
        public static ResponseModel CreateTask(TaskDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                using (var context = new DailyToolsContext())
                {
                    var task = new Task()
                    {
                        TaskId = Guid.NewGuid(),
                        UserName = model.UserName,
                        TaskName = model.TaskName,
                        TaskDateFrom = DateTime.Parse(model.TaskDateFromStr),
                        TaskDateTo = DateTime.Parse(model.TaskDateToStr),
                        TaskPrioriyCode = model.TaskPrioriyCode,
                        IsReminder = model.IsReminder,
                        IsActive = model.IsActive,
                        InputTime = DateTime.Now,
                        InputUn = model.UserName,
                        ModifTime = DateTime.Now,
                        ModifUn = model.UserName
                    };

                    context.Tasks.Add(task);
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

        public static ResponseModel DeleteTaskById(Guid taskId)
        {
            var response = new ResponseModel();

            try
            {
                var taskById = GetTaskById(taskId);

                if (taskById != null)
                {
                    var task = new DailyToolsContext().Tasks.Remove(taskById);
                    task.Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ResponseCode.ERROR;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public static IEnumerable<Task> GetAllTask()
        {
            var tasks = new DailyToolsContext().Tasks.AsEnumerable<Task>();
            return tasks;
        }

        public static Task GetTaskById(Guid taskId)
        {
            var task = new DailyToolsContext().Tasks.Where(task => task.TaskId == taskId).FirstOrDefault();
            return task;
        }

        public static ResponseModel UpdateTask(TaskDataLayer model)
        {
            var response = new ResponseModel();

            try
            {
                using(var context = new DailyToolsContext())
                {
                    var taskById = GetTaskById(model.TaskId);
                    if (taskById == null)
                    {
                        throw new Exception("Task for update not found");
                    }

                    taskById.TaskName = model.TaskName;
                    taskById.TaskDateFrom = DateTime.Parse(model.TaskDateFromStr);
                    taskById.TaskDateTo = DateTime.Parse(model.TaskDateToStr);
                    taskById.TaskPrioriyCode = model.TaskPrioriyCode;
                    taskById.IsReminder = model.IsReminder;
                    taskById.IsActive = model.IsActive;
                    taskById.ModifTime = DateTime.Now;
                    taskById.ModifUn = model.UserName;

                    context.Update<Task>(taskById);
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
