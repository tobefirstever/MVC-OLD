using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace JuegoOlimpico.Transversal.Common
{
    public class BaseClass
    {
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static readonly LogEventInfo TheEvent = new LogEventInfo(LogLevel.Error, "", "customs values");

        public BaseClass()
        {
            var loginClaim = HttpContext.Current.User.Identity;
            var claimsIdentity = loginClaim as ClaimsIdentity;
            if (claimsIdentity != null && claimsIdentity.Claims.FirstOrDefault(x => x.Type == "LoginModel") != null)
            {
                string loginClaimString = claimsIdentity.Claims.FirstOrDefault(x => x.Type == "LoginModel")?.Value;
                var loginModel = JsonConvert.DeserializeObject<LoginModel>(loginClaimString);
                TheEvent.Properties["IdSession"] = loginModel.IdSession;
            }
        }

        public void LogError(Exception e)
        {
            TheEvent.Message = "Exception";
            TheEvent.Exception = e;
            Logger.Error(TheEvent);
        }

        public void LogInfo(string info)
        {
            TheEvent.Message = info;
            TheEvent.Exception = null;
            Logger.Info(TheEvent);
        }
    }
}
