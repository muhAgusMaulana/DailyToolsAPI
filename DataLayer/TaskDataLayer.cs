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
        public short? TaskPrioriyCode { get; set; }
        public bool IsReminder { get; set; }
        public bool IsActive { get; set; }
    }
}
