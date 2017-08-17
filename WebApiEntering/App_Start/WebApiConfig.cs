using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApiEntering
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //bu aşağıdaki iki kod camelcase yapmaktır, yani property isimlerinin baş harfini küçük yazar. Kullanmaya çok da gerek yok ama bil yani. Bunu burada küçük yaparsan angularjs ile yazacağın appmodule ve Index içindeki database kolon isimlerini de küçük kullanman gerekir. Bu detaya dikkat edelim. Burayı yorum satırı yaparsan, O zaman database de orjinal halini almalısın, o da büyük zaten
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}
