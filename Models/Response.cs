using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class Response
    {
        public string ModuleName { get; set; }
        public string ResponseType { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
