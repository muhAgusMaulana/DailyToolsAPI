using System;

namespace DailyToolsAPI.DataLayer
{
    public class TaskDataLayer
    {
        public Guid TaskId { get; set; }
        public string UserName { get; set; }
        public string TaskName { get; set; }
        public string TaskDateFromStr { get; set; }
        public string TaskDateToStr { get; set; }
        public short? TaskPriorityCode { get; set; }
        public bool IsReminder { get; set; }
        public bool IsActive { get; set; }
    }

    public class TaskLogMessage
    {
        public string Field { get; set; }
        public object Before { get; set; }
        public object After { get; set; }
    }

    public enum TaskTransTypeCodeEnum
    {
        INIT,
        UPDT,
        DELT
    }
}
