using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oAuthTest.Models
{
    public static class UserDAL
    {
        public static UserDTO ValidateUser(String pLogin, String pPassword)
        {
            if (pLogin == "admin@yahoo.com" && pPassword == "admin")
            {
                return new UserDTO()
                {
                    UserID = "1",
                    Login = "admin@yahoo.com",
                    Name = "Admin"
                };
            }
            else
                return null;
        }

    }

    public class UserDTO
    {
        public String Login { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String UserID { get; set; }
    }
}