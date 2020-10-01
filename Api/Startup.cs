using System;
using Api.Data.Common.Extensions;
using Api.Data.Context;
using Api.Models.Models;
using Api.Repositories.Extensions;
using Api.Repositories.Interfaces;
using Api.Services.Extensions;
using Api.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataLayerWithSqlServer(Configuration);
            //or
            //services.AddDataLayerWithPostgreSql(Configuration);

            services.AddRepositories();
            services.AddServices();
            services.AddControllers();
           
            //Это стоило вынести в слой бизнес логики но его у тебя по сущего нет
            services.AddAutoMapper(typeof(Startup));
            
            services.AddControllers().AddNewtonsoftJson(e =>
            {
                e.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddSwaggerGen();
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
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}