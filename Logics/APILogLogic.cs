using DailyToolsAPI.DataLayer;
using DailyToolsAPI.DataLayer.ResponseDataLayer;
using DailyToolsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace DailyToolsAPI.Logics
{
    public class APILogLogic
    {
        public static void CreateLog(string controllerName, Exception exception, ResponseModel response, object param = null)
        {
            using (var context = new DailyToolsContext())
            {
                var log = new Apilog();
                log.ApilogId = Guid.NewGuid();
                log.Apiname = controllerName;
                log.Apiparam = param != null ? JsonConvert.SerializeObject(param) : string.Empty;
                log.Apiresponse = JsonConvert.SerializeObject(response);
                log.InputUn = "agus.maulana";

                if (exception != null)
                {
                    log.IsError = true;
                    log.Exception = JsonConvert.SerializeObject(exception);
                }

                context.Apilogs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
