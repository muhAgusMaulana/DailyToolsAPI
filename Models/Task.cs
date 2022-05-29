using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class Task
    {
        public Guid TaskId { get; set; }
        public string UserName { get; set; }
        public string TaskName { get; set; }
        public DateTime? TaskDateFrom { get; set; }
        public DateTime? TaskDateTo { get; set; }
        public short? TaskPriorityCode { get; set; }
        public bool IsReminder { get; set; }
        public bool IsActive { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
