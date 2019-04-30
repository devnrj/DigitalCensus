using System;
using DigitialCensus.Dotenet.Services.Interface;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Unity;

[assembly: OwinStartup(typeof(DigitalCensus.Dotnet.Web.Helper.Startup))]

namespace DigitalCensus.Dotnet.Web.Helper
{
    public class Startup
    {
        public static UnityContainer IoC { get; set; }

        public Startup() { }
        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(20),
                Provider = new AuthProvider(Startup.IoC.Resolve<IUserAccountService>(), Startup.IoC.Resolve<IUserService>())
            };

            //app.UseOAuthBearerTokens(options);
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
