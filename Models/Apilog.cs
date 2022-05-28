using System;
using System.Collections.Generic;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class Apilog
    {
        public Guid ApilogId { get; set; }
        public string Apiname { get; set; }
        public string Apiparam { get; set; }
        public string Apiresponse { get; set; }
        public bool IsError { get; set; }
        public string Exception { get; set; }
        public DateTime InputTime { get; set; }
        public string InputUn { get; set; }
    }
}
