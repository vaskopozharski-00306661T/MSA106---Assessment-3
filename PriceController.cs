using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static micrpService1.Startup;

namespace micrpService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {

        private readonly ILogger<PriceController> _logger;

        public PriceController(ILogger<PriceController> logger)
        {
            _logger = logger;
        }


        //public void loggers(string messagr)
        //{

        //    var url = "";
        //    var client = new System.Net.WebClient();
        //    //farkman
        //    url = "http://18.224.96.81/log/log?i=" + messagr;
        //    string temp = "";
        //    string response = client.DownloadString(url);
        //    if (!string.IsNullOrEmpty(response))
        //    {

        //        temp = response.ToString();
               


        //    }
        //}
        [HttpGet]
        public string Get(string me)
        {



            LoggerSharedText.LogToServcie("request recived");



            if (LoggerSharedText.Up == "ONLINE")
            {
                LoggerSharedText.LogToServcie("We are online and can serve requets");




                if (me == null)
                    me = "1";

                if (me.Equals("1"))
                {
                    LoggerSharedText.LogToServcie("logg microservice 12 returned price $100");
                    return "100 AUD";
                }
                if (me.Equals("2"))
                {
                    LoggerSharedText.LogToServcie("logg microservice 1  returned price $200");
                    return "200 AUD";
                }
                if (me.Equals("3"))
                {
                    LoggerSharedText.LogToServcie("logg microservice 1  returned price $300");
                    return "300 AUD";
                }
                else
                {

                    LoggerSharedText.LogToServcie("logg microservice 1 request price not found");
                    return "price not found";
                }

            }
            else
            {
                LoggerSharedText.LogToServcie("We are Offline and  and can not serve requets");
                return "Microservice is Offline";

            }
        }
    }
}
