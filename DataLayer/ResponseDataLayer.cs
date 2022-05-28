using System.Collections.Generic;
using System.Data;

namespace DailyToolsAPI.DataLayer.ResponseDataLayer
{
    public class ResponseModel
    {
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<string> ResponseMessageList { get; set; }
        public object Data { get; set; }

        public ResponseModel()
        {
            this.ResponseCode = ResponseCode.SUCCESS;
            this.ResponseMessage = "Success";
        }
    }

    public enum ResponseCode
    {
        SUCCESS,
        WARNING,
        ERROR
    }
}
