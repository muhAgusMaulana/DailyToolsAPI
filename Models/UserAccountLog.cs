using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class UserAccountLog
    {
        public Guid UserAccountLogId { get; set; }
        public Guid UserAccountId { get; set; }
        public string OperationType { get; set; }
        public decimal Amount { get; set; }
        public Guid? TargetUserAccountId { get; set; }
        public string Remarks { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
