using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizBack.Repositories;
using QuizBack.Services;

namespace QuizBack
{
    public class Startup
    {
        private const string Headers = "Authorization,Accept,Content-Type,Accept-Encoding,Accept-Language,Connection,Cookie,Host,Origin,Referer,Sec-Fetch-Dest,Sec-Fetch-Mode,Sec-Fetch-Site,User-Agent";
        private const string Methods = "GET,POST,PUT,DELETE";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddPolicy("GlobalCors",
                builder =>
                {
                    builder.WithHeaders(Headers.Trim().Split(",").ToArray());
                    builder.WithExposedHeaders("Set-Cookie");
                    builder.WithOrigins("http://localhost:3000");
                    builder.WithMethods(Methods.Trim().Split(",").ToArray());
                    builder.AllowCredentials();
                });
            });

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuizBack", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuizBack v1"));
            }

            app.UseCors("GlobalCors");

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
