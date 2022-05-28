using System;

namespace DailyToolsAPI.DataLayer
{
    public class UserAccountDataLayer
    {
        public Guid UserAccountId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public decimal AmountBalance { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserAccountLogDataLayer
    {
        public string UserName { get; set; }
        public string DateFromStr { get; set; }
        public string DateToStr { get; set; }
        public string OperationType { get; set; }
        public string SourceType { get; set; }
    }

    public class NewUserAccountDataLayer
    {
        public string UserName { get; set; }
        public string AccountType { get; set; }
    }
}
