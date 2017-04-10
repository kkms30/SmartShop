using Newtonsoft.Json;
using SmartShopWebApp.Core.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SmartShopWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Clear();

        

            JsonMediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            //jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            //jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);

           
        }
    }
}
