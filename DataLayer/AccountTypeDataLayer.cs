using System.ComponentModel.DataAnnotations;

namespace DailyToolsAPI.DataLayer
{
    public class AccountTypeDataLayer
    {
        private string _accountTypeCode;

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

        [Required]
        public string AccountTypeName { get; set; }
    }
}
