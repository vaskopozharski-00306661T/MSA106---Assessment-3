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
    public class UpController : ControllerBase
    {

        private readonly ILogger<UpController> _logger;

        public UpController(ILogger<UpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string me)
        {
            LoggerSharedText.LogToServcie("logg microservice 1 request recived for status");
            LoggerSharedText.LogToServcie("logg microservice 1 returnt  status " + LoggerSharedText.Up);

            return LoggerSharedText.Up;

        }
    }

    [ApiController]
    [Route("[controller]")]
    public class StopController : ControllerBase
    {

        private readonly ILogger<UpController> _logger;

      

        [HttpGet]
        public void Get(string me)
        {
            LoggerSharedText.LogToServcie("logg microservice 1 request recived to STOP service");

             LoggerSharedText.Up = "STOPPED";


            LoggerSharedText.LogToServcie("logg microservice 1  service is stopped " + LoggerSharedText.Up);




        }
    }


    [ApiController]
    [Route("[controller]")]
    public class StartController : ControllerBase
    {

        private readonly ILogger<StartController> _logger;



        [HttpGet]
        public void Get(string me)
        {
            LoggerSharedText.LogToServcie("logg microservice 1 request recived to START service");

            LoggerSharedText.Up = "ONLINE";


            LoggerSharedText.LogToServcie("logg microservice 1  service is : " + LoggerSharedText.Up);




        }
    }



}
