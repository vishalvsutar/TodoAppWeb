using System.Web.Http;
using WebActivatorEx;
using mvcToDoList;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace mvcToDoList
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "mvcToDoList");

                         })
                .EnableSwaggerUi(c =>
                    {
                        });
        }
    }
}