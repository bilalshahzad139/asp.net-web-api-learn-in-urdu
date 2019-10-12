using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
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

        [HttpGet]
        public String Test()
        {
            var accessToken = "2wtL7hU4pHVdblFMBpS4l1Kwn6RP5_l_8pTp3PGS7tb4qetsCcuRNDzWmcM1oEpIMprjAgbEDB6XZ8WI4Y0yUEm-e39B3Eqnee2XD59Bs6x2S6L3mwHU7CyP3lzZpL8HxRiqBlwk2rY83DyB_AF-itWFHCOtPAjfW0tBvWh-gZFekmhpYS5aTF16J4bD4EWZ-lo-Ma-L3OC4ep1R1xhWsuAYWDY-j_7zOYeEmAtbPJDt8iDqBQ4okL5aCYZBbIh26Km1CIGSEccWygM3I_-lwQ";
            var secureDataFormat = new TicketDataFormat(new MachineKeyProtector());
            AuthenticationTicket ticket = secureDataFormat.Unprotect(accessToken);

            return "";
        }
    }





    class MachineKeyProtector : IDataProtector
    {
        private readonly string[] _purpose =
        {
        typeof(OAuthAuthorizationServerMiddleware).Namespace,
        "Access_Token",
        "v1"
    };

        public byte[] Protect(byte[] userData)
        {
            throw new NotImplementedException();
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            return System.Web.Security.MachineKey.Unprotect(protectedData, _purpose);
        }
    }
}