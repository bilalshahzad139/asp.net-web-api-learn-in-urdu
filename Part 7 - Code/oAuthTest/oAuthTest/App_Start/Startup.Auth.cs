using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using oAuthTest.Provider;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oAuthTest
{
    [assembly: OwinStartup(typeof(oAuthTest.Startup))]
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new oAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                AllowInsecureHttp = true
            };
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}