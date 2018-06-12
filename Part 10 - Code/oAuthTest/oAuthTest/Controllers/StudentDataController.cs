using oAuthTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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

        [Authorize]
        [HttpGet]
        public String GetUserAddress()
        {
            var claims = Request.GetOwinContext().Authentication.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Name)
                {
                    var name = claim.Value;
                }
                if (claim.Type == "UserID")
                {
                    var userid = claim.Value;
                    //Get user id
                }
            }

            var uniqueName = User.Identity.Name;
            var address = UserDAL.GetAddressByLogin(uniqueName);
            return address;
        }
    }
}