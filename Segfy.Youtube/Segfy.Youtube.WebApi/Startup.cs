using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Segfy.Youtube.Core.Provider;
using Segfy.Youtube.Core.Repository;
using Segfy.Youtube.Core.Repository.MongoDb;
using Segfy.Youtube.WebApi.Commom;
using Segfy.Youtube.WebApi.Properties;

namespace Segfy.Youtube.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton((f) =>
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(typeof(YourYoutubeAutoMapperProfile));
                });

                mapperConfig.AssertConfigurationIsValid();
                var mapper = mapperConfig.CreateMapper();
                return mapper;
            });

            services.AddSingleton(new YoutubeApiProvider(Resources.YoutubeApiKey));
            services.AddScoped<IYoutubeRepository>((f) => new MongoDbYoutubeRepository(Resources.MongoDbConnection));

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(f => f.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
