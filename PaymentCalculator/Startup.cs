using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentCalculator.Services;
using Microsoft.OpenApi.Models;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Steeltoe.Connector.Redis;

namespace PaymentCalculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // access to VCAP_ variables in cloud foundry
            services.AddOptions();
            services.ConfigureCloudFoundryOptions(Configuration);

            services.AddControllers();
            services.AddCors();
            services.AddOptions();
            services.AddSingleton<PaymentService>();
            services.AddSingleton<CrashService>();

            if(Env.IsDevelopment())
            {
                services.AddSingleton<IHitCounterService, MemoryHitCounterService>();
            }
            else
            {
                services.AddRedisConnectionMultiplexer(Configuration);
                services.AddSingleton<IHitCounterService, RedisHitCounterService>();
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
