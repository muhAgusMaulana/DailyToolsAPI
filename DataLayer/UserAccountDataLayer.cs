using System;

namespace DailyToolsAPI.DataLayer
{
    public class UserAccountDataLayer
    {
        public Guid UserAccountId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AccountTypeName { get; set; }
        public decimal AmountBalance { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserAccountLogDataLayer
    {
        public string UserName { get; set; }
        public string DateFromStr { get; set; }
        public string DateToStr { get; set; }
        public string OperationType { get; set; }
    }

    public class NewUserAccountDataLayer
    {
        public string UserName { get; set; }
        public string AccountTypeCode { get; set; }
    }

    public class UserAccountTransactionDataLayer
    {
        public Guid UserAccountId { get; set; }
        public string UserName { get; set; }
        public string OperationType { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public Guid? TargetUserAccountId { get; set; }
    }

    public enum OperationTypeEnum
    {
        DEBT,
        CRDT,
        TRFR
    }
}
