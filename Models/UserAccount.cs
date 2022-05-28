using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class UserAccount
    {
        public Guid UserAccountId { get; set; }
        public string UserName { get; set; }
        public string AccountTypeCode { get; set; }
        public decimal AmountBalance { get; set; }
        public bool IsActive { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
