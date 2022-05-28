using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class UserAccountLog
    {
        public Guid UserAccountLogId { get; set; }
        public string OperationType { get; set; }
        public string SourceType { get; set; }
        public string TargetType { get; set; }
        public decimal AmountBalance { get; set; }
        public Guid? TargetAccountId { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
