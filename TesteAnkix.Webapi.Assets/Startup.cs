using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using TesteAnkix.Webapi.Application.Configurations;

namespace TesteAnkix.Webapi.Assets
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationBuilder Builder { get; }

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Builder = new ConfigurationBuilder().SetBasePath(Path.Combine(env.ContentRootPath, "Settings"))
                                                .AddJsonFile($"appsettings.json", true);

            if (env.IsDevelopment())
            {
                Builder.AddUserSecrets<Startup>();
            }
            Builder.AddEnvironmentVariables();

            Configuration = Builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteAnkix.WebApi.Assets", Version = "v1" });
            });

            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(setup => setup.CustomSchemaIds(t => t.ToString()));
            services.ConfigureDependencies(Configuration);
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 10;
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteAnkix.WebApi.Assets v1"));
            //}

            app.UseRouting();
            app.UseCors(it => it.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

