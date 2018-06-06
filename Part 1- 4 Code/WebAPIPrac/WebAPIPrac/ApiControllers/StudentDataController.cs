using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIPrac.ApiControllers
{

    [EnableCors(origins: "http://localhost:12150", headers: "*", methods: "*")]
    public class StudentDataController : ApiController
    {
        [HttpGet]
        public int GetData1()
        {
            return 10;
        }

        [HttpGet]
        public int GetData2(int a, int b) //Get data from query string
        {
            return a + b;
        }

        [HttpPost]
        public String Save(StudentDTO dto) //Get data from body
        {
            return dto.name + "-testing";
        }

    }

    public class StudentDTO
    {
        public int id { get; set; }
        public String name { get; set; }
    }
}