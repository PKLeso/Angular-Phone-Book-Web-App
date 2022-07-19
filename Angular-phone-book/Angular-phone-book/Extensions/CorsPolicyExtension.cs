using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Angular_phone_book.Extensions
{
    public static class CorsPolicyExtension
    {
        public static void AddCorsPolicy(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ËnableCorsForAngularApp",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddControllers()
                    .AddJsonOptions(x =>
                    {
                        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        x.JsonSerializerOptions.IgnoreNullValues = true;
                    });
        }
    }
}