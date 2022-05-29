using System;
using System.ComponentModel.DataAnnotations;

namespace DailyToolsAPI.DataLayer
{
    public class UserAccountDataLayer
    {
        public Guid UserAccountId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string AccountTypeName { get; set; }

        [Required]
        public decimal AmountBalance { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    public class UserAccountLogDataLayer
    {
        private string _operationType;

        [Required]
        public string UserName { get; set; }

        [Required]
        public string DateFromStr { get; set; }

        [Required]
        public string DateToStr { get; set; }

        [Required]
        public string OperationType
        {
            get
            {
                return !string.IsNullOrEmpty(_operationType) ? _operationType.ToUpper() : string.Empty;
            }

            set
            {
                _operationType = value.ToUpper();
            }
        }
    }

    public class NewUserAccountDataLayer
    {
        private string _accountTypeCode;

        [Required]
        public string UserName { get; set; }

        [Required]
        public string AccountTypeCode
        {
            get 
            {
                return !string.IsNullOrEmpty(_accountTypeCode) ? _accountTypeCode.ToUpper() : string.Empty;
            }

            set 
            { 
                _accountTypeCode = value.ToUpper(); 
            }
        }
    }

    public class UserAccountTransactionDataLayer
    {
        private string _operationType;

        [Required]
        public Guid? UserAccountId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string OperationType 
        { 
            get 
            {
                return !string.IsNullOrEmpty(_operationType) ? _operationType.ToUpper() : string.Empty;
            } 

            set 
            { 
                _operationType = value.ToUpper(); 
            } 
        }

        [Required]
        public decimal Amount { get; set; }

        [Required]
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
