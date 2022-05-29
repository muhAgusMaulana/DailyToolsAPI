using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DailyToolsAPI.Logics
{
    public class TaskLogic
    {
        public static void CreateTask(TaskDataLayer model)
        {
            using (var context = new DailyToolsContext())
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    Guid taskId = Guid.NewGuid();

                    var task = new Task()
                    {
                        TaskId = taskId,
                        UserName = model.UserName,
                        TaskName = model.TaskName,
                        TaskDateFrom = DateTime.Parse(model.TaskDateFromStr),
                        TaskDateTo = DateTime.Parse(model.TaskDateToStr),
                        TaskPriorityCode = model.TaskPriorityCode,
                        IsReminder = model.IsReminder,
                        IsActive = model.IsActive,
                        InputTime = DateTime.Now,
                        InputUn = model.UserName,
                        ModifTime = DateTime.Now,
                        ModifUn = model.UserName
                    };

                    var taskLog = new TaskLog()
                    {
                        TaskId = taskId,
                        TaskTransTypeCode = nameof(TaskTransTypeCodeEnum.INIT),
                        TaskLogMessage = string.Empty,
                        InputTime = DateTime.Now,
                        InputUn = model.UserName
                    };

                    context.Tasks.Add(task);
                    context.TaskLogs.Add(taskLog);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex);
                }
            }
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

        public static void UpdateTask(TaskDataLayer model)
        {
            using (var context = new DailyToolsContext())
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    var task = GetTaskById(model.TaskId.Value);

                    if (task == null)
                    {
                        throw new Exception("Task for update not found");
                    }

                    var taskLogMessage = new List<TaskLogMessage>();
                    if (task.TaskName != model.TaskName)
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.TaskName),
                            Before = task.TaskName,
                            After = model.TaskName
                        });
                    }
                    
                    if (task.TaskDateFrom != DateTime.Parse(model.TaskDateFromStr))
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.TaskDateFrom),
                            Before = task.TaskDateFrom,
                            After = DateTime.Parse(model.TaskDateFromStr)
                        });
                    }
                    
                    if (task.TaskDateTo != DateTime.Parse(model.TaskDateToStr))
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.TaskDateTo),
                            Before = task.TaskDateTo,
                            After = DateTime.Parse(model.TaskDateToStr)
                        });
                    }

                    if (task.TaskPriorityCode != model.TaskPriorityCode)
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.TaskPriorityCode),
                            Before = task.TaskPriorityCode,
                            After = model.TaskPriorityCode
                        });
                    }
                    
                    if (task.IsReminder != model.IsReminder)
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.IsReminder),
                            Before = task.IsReminder,
                            After = model.IsReminder
                        });
                    }
                    
                    if (task.IsActive != model.IsActive)
                    {
                        taskLogMessage.Add(new TaskLogMessage
                        {
                            Field = nameof(task.IsActive),
                            Before = task.IsActive,
                            After = model.IsActive
                        });
                    }

                    var taskLog = new TaskLog()
                    {
                        TaskId = task.TaskId,
                        TaskTransTypeCode = model.IsActive ? nameof(TaskTransTypeCodeEnum.UPDT) : nameof(TaskTransTypeCodeEnum.DELT),
                        TaskLogMessage = taskLogMessage.Count > 0 && model.IsActive ? JsonConvert.SerializeObject(taskLogMessage) : string.Empty,
                        InputTime = DateTime.Now,
                        InputUn = "agus.maulana"
                    };

                    task.TaskName = model.TaskName;
                    task.TaskDateFrom = DateTime.Parse(model.TaskDateFromStr);
                    task.TaskDateTo = DateTime.Parse(model.TaskDateToStr);
                    task.TaskPriorityCode = model.TaskPriorityCode;
                    task.IsReminder = model.IsReminder;
                    task.IsActive = model.IsActive;
                    task.ModifTime = DateTime.Now;
                    task.ModifUn = model.UserName;

                    context.Tasks.Update(task);
                    context.TaskLogs.Add(taskLog);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
