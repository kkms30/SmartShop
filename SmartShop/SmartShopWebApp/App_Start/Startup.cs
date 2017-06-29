using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SmartShopWebApp.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp
{
    public partial class Startup
    {
        private const string TokenEndpoint = "/token";
        public static OAuthAuthorizationServerOptions OauthOptions { get; set; }

        static Startup()
        {
            OauthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString(TokenEndpoint),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OauthOptions);
        }
    }
}