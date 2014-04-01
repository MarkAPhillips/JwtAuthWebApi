using Security;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Tracing;

namespace WebApi
{
    public static class WebApiConfig
    {
        /// <summary>
        /// This is the only method that all hosts should call to initialize the WebAPI.
        /// This method takes in an HttpConfiguration and sets up the routes, formatters,
        /// enables CORS, and also invokes other initializers.
        /// </summary>
        /// <param name="config">
        /// IIS Hosted : GlobalConfiguration.Configuration
        /// Self Hosted: new HttpConfiguration()
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            //Enable CORS. Do not add move this to web.config. PUT and POST will not work.
            var attrs = new EnableCorsAttribute("*", "*", "*"); //To be restricted properly in Production
            config.EnableCors(attrs);

            // Attribute routing.
            config.MapHttpAttributeRoutes();

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault((t => t.MediaType == "application/xml")));

            config.MessageHandlers.Add(new TokenValidationHandler());
        }
    }
}