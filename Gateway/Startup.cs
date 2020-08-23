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

namespace gateway
{

    public static class LoggerSharedText
    {

        public static string Up = new string("NOT READY");
        public static int counter = 0;
        public static bool service1Online = false;
        public static bool service2Online = false;
        public static string Name = new string("Microservice 1 A");

        //  
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


        public static void ActionToServcie(string ip, string todo)
        {
            var url = "";
            var client = new System.Net.WebClient();
          
            url = "http://"+ ip +"/" + todo  ;

            string temp = "";
            string response = client.DownloadString(url);
            if (!string.IsNullOrEmpty(response))
            {
                temp = response.ToString();

            }
        }




        public static void CheckStatus(string ip)
        {
            LoggerSharedText.LogToServcie("Gate way is checking status for MS ip : " + ip );
            var url = "";
            var client = new System.Net.WebClient();



            LoggerSharedText.LogToServcie("Request being sent to mirco service 1 A");


            url = "http://" + ip + "/up";
            string temp = "";
            string response = client.DownloadString(url);
            if (!string.IsNullOrEmpty(response))
            {

                temp = response.ToString();


                if (temp == "ONLINE") {

                    if(ip == "13.58.147.235")
                    {
                        LoggerSharedText.service1Online = true;
                        LoggerSharedText.LogToServcie("Result back from  mirco service 1 is : " + temp);
                    }

                        if (ip == "3.12.85.38")
                    {
                        LoggerSharedText.service2Online = true;
                        LoggerSharedText.LogToServcie("Result back from  mirco service 1 is : " + temp);
                 
                    }







                }
                else
                {
                    LoggerSharedText.LogToServcie("Result back from  mirco service 1 is : " + temp);
                    LoggerSharedText.service1Online = false;
                }


               

            }
            else
            {
                LoggerSharedText.LogToServcie("Result back from  mirco service 1 is OFFLOINE: ");
                LoggerSharedText.service1Online = false;
            }

        }
    }



    //}


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LoggerSharedText.LogToServcie("Gateway Micro Service " + LoggerSharedText.Name + "  status " + LoggerSharedText.Up);
            LoggerSharedText.LogToServcie("Gateway Micro Service " + LoggerSharedText.Name + " is starting ");
            LoggerSharedText.Up = "ONLINE";
            LoggerSharedText.LogToServcie("Gateway Micro Service " + LoggerSharedText.Name + "  status " + LoggerSharedText.Up);

            LoggerSharedText.LogToServcie("Gateway Micro Service Checking MicroService Clluster " );


            LoggerSharedText.CheckStatus("3.12.85.38");

            LoggerSharedText.LogToServcie("Gateway Micro Service Checked Node 1 ");

            LoggerSharedText.CheckStatus("13.58.147.235");

            LoggerSharedText.LogToServcie("Gateway Micro Service Checked Node 2 ");




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
