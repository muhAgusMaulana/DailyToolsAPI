using System;
using System.ComponentModel.DataAnnotations;

namespace DailyToolsAPI.DataLayer
{
    public class TaskDataLayer
    {
        public Guid? TaskId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public string TaskDateFromStr { get; set; }

        [Required]
        public string TaskDateToStr { get; set; }

        [Required]
        public short? TaskPriorityCode { get; set; }

        [Required]
        public bool IsReminder { get; set; }

        [Required]
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
