using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace micrpService2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class quantityController : ControllerBase
    {

        private readonly ILogger<quantityController> _logger;

        public quantityController(ILogger<quantityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string me)
        {

            if (me == null)
                me = "1";

            if (me.Equals("1"))
                return "100 quantity";
            if (me.Equals("2"))
                return "200 quantity";
            if (me.Equals("3"))
                return "300 quantity";
            else
                return "WRONG quantity";
        }
    }

}
