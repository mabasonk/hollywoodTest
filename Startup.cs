using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HollywoodTest.Domain.IRepositories;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Persistence.Contexts;
using HollywoodTest.Persistence.Repositories;
using HollywoodTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HollywoodTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("hollywood-test");
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});

            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IEventService, EventService>();

            services.AddAutoMapper(typeof(Startup));
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
