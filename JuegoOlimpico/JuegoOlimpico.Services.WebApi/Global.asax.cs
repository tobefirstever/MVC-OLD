using NLog;
using System;
using System.Web;
using System.Web.Http;

namespace JuegoOlimpico.Services.WebApi
{
    /// <summary>
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// </summary>
        public static readonly Logger Logger;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {
            LogManager.Shutdown();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Logger?.Error(exception);
        }

        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            if (GlobalConfiguration.Configuration != null)
            {
                GlobalConfiguration.Configuration.Formatters?.XmlFormatter?.SupportedMediaTypes?.Clear();
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
