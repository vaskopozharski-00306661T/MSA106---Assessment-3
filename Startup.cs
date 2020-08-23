using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace micrpService1
{
    public class Startup
    {

        public static class LoggerSharedText
        {

            public static string Up = new string("NOT READY");
            public static string Name = new string("Microservice 2 B");

            public static void LogToServcie(string messagr)
            {
                var url = "";
                var client = new System.Net.WebClient();
                //farkman
                url = "http://18.224.96.81/log/log?i=" + Name + "  : " + messagr;
                string temp = "";
                string response = client.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {
                    temp = response.ToString();

                }
            }


        }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoggerSharedText.LogToServcie("Micro Service " + LoggerSharedText.Name + "  status " + LoggerSharedText.Up );
            LoggerSharedText.LogToServcie("Micro Service " + LoggerSharedText.Name   + " is starting ");
            LoggerSharedText.Up = "ONLINE";
            LoggerSharedText.LogToServcie("Micro Service " + LoggerSharedText.Name + "  status " + LoggerSharedText.Up);
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
