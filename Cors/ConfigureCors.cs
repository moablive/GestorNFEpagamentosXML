namespace GestorNFEpagamentosXML.Cors
{
    public static class ConfigureCors
    {
        public static void CorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("localhost", policy =>
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}