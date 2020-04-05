using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FindRideToWork.Infrastructure.InfrastructureModules;
using FindRideToWork.Infrastructure.Services;
using FindRideToWork.Infrastructure.Repositories;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.Mapper;
using Microsoft.OpenApi.Models;
using FindRideToWork.Infrastructure.Repositories.InMemoryReposiories;
using Microsoft.IdentityModel.Tokens;
using FindRideToWork.Infrastructure.Mongo;
using FindRideToWork.Infrastructure.Helpers.Extensions;
using FindRideToWork.Infrastructure.Settings;
using System.Text;
using FindRideToWork.Infrastructure.Auth;

namespace FindRideToWork.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddSingleton(AutoMapperConfiguration.Init());
            services.AddControllers();
            services.AddJwtAuthentication(Configuration);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                   .SingleInstance();
            builder.RegisterModule(new Modules(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {      

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MongoConfigurator.Initialize();
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            applicationLifetime.ApplicationStopped.Register(() => AutofacContainer.Dispose());

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var swaggerOptions = app.ApplicationServices.GetService<SwaggerOptions>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

        }
    }
}
