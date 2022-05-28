using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class AccountType
    {
        public string AccountTypeCode { get; set; }
        public string AccountName { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
        public DateTime ModifTime { get; set; }
        public string ModifUn { get; set; }
    }
}
