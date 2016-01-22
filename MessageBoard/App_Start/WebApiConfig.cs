using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace MessageBoard {
    public static class WebApiConfig {

        public static void Register(HttpConfiguration configuration) {
            
            var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            configuration.Routes.MapHttpRoute("RepliesRoute", "api/v1/topics/{topicid}/replies/{id}",
               new { controller = "replies", id = RouteParameter.Optional });

            configuration.Routes.MapHttpRoute("API Default", "api/v1/topics/{id}",
                new { controller = "topics", id = RouteParameter.Optional });
        }

    }
}