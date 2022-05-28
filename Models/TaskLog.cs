using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class TaskLog
    {
        public Guid TaskLogId { get; set; }
        public Guid TaskId { get; set; }
        public short TaskTypeCode { get; set; }
        public string TaskLogMessage { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
