using FinalProjectGroup2.Context;
using FinalProjectGroup2.Data;
using FinalProjectGroup2.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectGroup2
{
    public class Startup
    {
        //...
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //added here
            services.AddSwaggerDocument();
            services.AddDbContext<MemberinfoContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("MemberinfoContext")));
            services.AddDbContext<MusicContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("MusicContext")));

            services.AddDbContext<FoodContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FoodContext")));
            services.AddScoped<IFoodContextDAO, FoodContextDAO>();
            services.AddDbContext<MusicContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("MusicContext")));
            services.AddDbContext<HobbyContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("HobbyContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FoodContext fcontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //added here
            app.UseOpenApi();

            app.UseSwaggerUi3();

            fcontext.Database.Migrate();

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
