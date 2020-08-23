using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class qty : ControllerBase
    {
        private readonly ILogger<qty> _logger;

        public qty(ILogger<qty> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string me)
        {

            var url = "";
            var client = new WebClient();
            url = "http://3.14.79.73/quantity?me=" + me;
            string temp = "";
            string response = client.DownloadString(url);
            if (!string.IsNullOrEmpty(response))
            {

                temp = response.ToString();
                return temp;

            }
            return "0";
        }

    }


    [ApiController]
        [Route("[controller]")]
        public class price : ControllerBase
        {

            private readonly ILogger<price> _logger;

            public price(ILogger<price> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public string Get(string me)
            {

            LoggerSharedText.counter++;
                LoggerSharedText.LogToServcie("Request recived in gate way");
                var url = "";
                var client = new WebClient();


            if (LoggerSharedText.counter % 2 == 0)
            {
                LoggerSharedText.LogToServcie("Request is EVEN SHOULD ----> sent to mirco service 1 ");
            }
            else
            {
                LoggerSharedText.LogToServcie("Request is ODD SHOULD ----> sent to mirco service 2 ");
            }
           

            if (LoggerSharedText.counter % 2 == 0 && LoggerSharedText.service1Online) {

                LoggerSharedText.LogToServcie("Request is EVEN being sent to mirco service 1 ");

                url = "http://13.58.147.235/price?me=" + me;
                string temp = "";
                string response = client.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {

                    temp = response.ToString();

                    LoggerSharedText.LogToServcie("Result back from  mirco service 1 is : " + temp);



                    return temp;

                }

            }
            else {
                if( LoggerSharedText.service2Online) { 
                LoggerSharedText.LogToServcie("Request is ODD being sent to mirco service 2");

                url = "http://3.12.85.38/price?me=" + me;
                string temp = "";
                string response = client.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {

                    temp = response.ToString();

                    LoggerSharedText.LogToServcie("Result back from  mirco service 2 is : " + temp);



                    return temp;

                }
                }
                else
                {
                    LoggerSharedText.LogToServcie("Request is ODD being sent to mirco service 1 DUE TO 2 OFFLINE");

                    url = "http://13.58.147.235/price?me=" + me;
                    string temp = "";
                    string response = client.DownloadString(url);
                    if (!string.IsNullOrEmpty(response))
                    {

                        temp = response.ToString();

                        LoggerSharedText.LogToServcie("Result back from  mirco service 1 is : " + temp);
                    


                        return temp;

                    }

                }
            }











          
                return "0";
            }
        }



    [ApiController]
    [Route("[controller]")]
    public class loadtest : ControllerBase
    {

        private readonly ILogger<loadtest> _logger;

        public loadtest(ILogger<loadtest> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string me)
        {
            LoggerSharedText.LogToServcie("Request recived in gate way FOR LOAD TEST FOR : " + me + "  time " );
            var url = "";
            var client = new WebClient();



            LoggerSharedText.LogToServcie("Request being sent to mirco service 1");

            for (int i = 0; i < Convert.ToInt32(me); i++)
            {
                url = "https://localhost:44376/price?me=" + i;
                string temp = "";
                string response = client.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {

                    temp = response.ToString();

                    LoggerSharedText.LogToServcie("LOAD TEST : "  +  i +  " : Result back from  mirco service 1 is : " + temp);



                  

                }
            }
           
            return "0";
        }
    }



    [ApiController]
    [Route("[controller]")]
    public class stop1 : ControllerBase
    {


        [HttpGet]
        public void  Get()
        {
            LoggerSharedText.LogToServcie("Request recived in gate to stop service 1 ");

            LoggerSharedText.ActionToServcie("13.58.147.235", "Stop");

            LoggerSharedText.service1Online = false;


        }
    }

    [ApiController]
    [Route("[controller]")]
    public class start1 : ControllerBase
    {


        [HttpGet]
        public  void Get(string me)
        {
            LoggerSharedText.LogToServcie("Request recived in gate to start service 1 ");

            LoggerSharedText.ActionToServcie("13.58.147.235", "Start");

            LoggerSharedText.service1Online = true;



        }
    }



    [ApiController]
    [Route("[controller]")]
    public class stop2 : ControllerBase
    {


        [HttpGet]
        public  void Get()
        {

            LoggerSharedText.service2Online = false;


            LoggerSharedText.LogToServcie("Request recived in gate to stop service 2 ");

            LoggerSharedText.ActionToServcie("3.12.85.38", "Stop");

        }
    }

    [ApiController]
    [Route("[controller]")]
    public class start2 : ControllerBase
    {


        [HttpGet]
        public void  Get(string me)
        {

            LoggerSharedText.service2Online = true;



            LoggerSharedText.LogToServcie("Request recived in gate to start service 2 ");

            LoggerSharedText.ActionToServcie("3.12.85.38", "Start");

        }
    }

}

