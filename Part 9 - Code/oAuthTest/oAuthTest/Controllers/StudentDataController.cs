using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace oAuthTest.Controllers
{
    public class StudentDataController : ApiController
    {
        [Authorize]
        [HttpGet]
        public int GetData1()
        {
            return 10;
        }
    }
}