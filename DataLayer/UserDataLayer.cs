using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace DailyToolsAPI.DataLayer.UserDataLayer
{
    public class UserModel
    {
        private string _email;

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,150}$")]
        public string FullName { get; set; }

        [Required]
        public string Email 
        { 
            get
            {
                return string.IsNullOrEmpty(_email) ? _email : string.Empty;
            }

            set
            {
                try
                {
                    var m = new MailAddress(value);
                    _email = value;
                }
                catch (FormatException)
                {
                    throw new Exception("Email formati is not valid");
                }
            }
        }

        public string Phone { get; set; }

        public string Address { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
