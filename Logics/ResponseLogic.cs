using DailyToolsAPI.Models;
using System.Linq;

namespace DailyToolsAPI.Logics
{
    public class ResponseLogic
    {
        public static Response GetResponseMessage(string moduleName, string responseType, string responseCode)
        {
            var response = new DailyToolsContext().Responses
                .Where(item => item.ModuleName == moduleName 
                    && item.ResponseType == responseType 
                    && item.ResponseCode == responseCode)
                .FirstOrDefault();

            return response;
        }
    }
}
