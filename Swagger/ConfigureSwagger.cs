using Microsoft.OpenApi.Models;

namespace GestorNFEpagamentosXML.Swagger
{
    public static class ConfigureSwagger
    {
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestorNFEpagamentosXML", Version = "v1" });
            });
        }
    }
}