using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Middleware;
using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.Repositories;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AnimatedSeriesAPI
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
            services.AddAuthenticationLayer(Configuration);
            services.AddControllers().AddFluentValidation().AddNewtonsoftJson();
            services.AddPersistanceLayer(Configuration, this);
            services.AddValidationLayer();
            services.AddSwaggerGen();
            services.AddCorsPolicy(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeriesSeeder seeder)
        {
            app.UseCors("FrontEndClient");

            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimatedSeriesAPI v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
