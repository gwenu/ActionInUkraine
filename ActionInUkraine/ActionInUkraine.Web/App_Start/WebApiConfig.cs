﻿using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace ActionInUkraine.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ex: api/persons
            config.Routes.MapHttpRoute(
                        name: "ControllerOnly",
                        routeTemplate: "api/{controller}"
                    );// ex: api/sessionbriefs

            //  ex: api/persons/1
            config.Routes.MapHttpRoute(
                        name: "ControllerAndId",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: null, //defaults: new { id = RouteParameter.Optional } //,
                        constraints: new { id = @"^\d+$" } // id must be all digits
                    );

            // ex: api/lookups/all
            // ex: api/lookups/rooms
            config.Routes.MapHttpRoute(
                        name: "ControllerAction",
                        routeTemplate: "api/{controller}/{action}"
                    );


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            // Use camel case for JSON data.
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}