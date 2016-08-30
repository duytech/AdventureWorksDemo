namespace AW.WebAPI
{
    using Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // config.MapHttpAttributeRoutes() need to be called before config.MapODataServiceRoute()
            WebApiRegister(config);
            OdataRegister(config);
        }

        private static void WebApiRegister(HttpConfiguration config)
        {
            // Add exception filter to catch all exception occur in action method
            config.Filters.Add(new ApplicationExceptionFilter());

            // Add global exeption handler
            config.Services.Replace(typeof(IExceptionHandler), new ApplicationExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        private static void OdataRegister(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.Employee>("Employees");
            builder.EntitySet<Models.EmployeeDepartmentHistory>("EmployeeDepartmentHistories");
            builder.EntitySet<Models.Shift>("Shifts");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());

            // create the formatters with the custom serializer provider and use them in the configuration.
            //var odataFormatters = ODataMediaTypeFormatters.Create(new AppODataSerializerProvider(), new DefaultODataDeserializerProvider());
            //config.Formatters.InsertRange(0, odataFormatters);

            // OData has its own action method convention name.
            // Need to be registered here if any
            //ActionConfiguration saveShift = builder.EntityType<Models.Shift>().Action("Save");
            //saveShift.Parameter<Models.Shift>("shift");
            //saveShift.Returns<HttpResponseMessage>();
        }
    }
}
