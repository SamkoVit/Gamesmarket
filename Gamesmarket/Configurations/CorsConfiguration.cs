namespace Gamesmarket.Configurations
{
    public static class CorsConfiguration
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("frontend", opt =>
            {
                opt.WithOrigins("http://localhost:3000", "http://localhost", "https://orange-island-002961f03.6.azurestaticapps.net")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
            }));
        }
    }

}
