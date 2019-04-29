using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace DigitalCensus.Dotnet.Web.Helper
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;
        private IUserAccountService _service;
        public AuthProvider() { }
        public AuthProvider(IUserAccountService service, IUserService userService)
        {
            _userService = userService;
            _service = service;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            UserAccountDto user = new UserAccountDto
            {
                Email = context.UserName,
                Password = context.Password
            }
            Guid authUserID = _service.Get(user);
            if (authUserID != null && authUserID != Guid.Empty)
            {
                UserDto authUser = _userService.GetUserByAccountID(authUserID);
                identity.AddClaim(new Claim(ClaimTypes.Role, Convert.ToString(authUser.IsApprover)));
                identity.AddClaim(new Claim("Status", Convert.ToString(authUser.RequestStatus)));
                identity.AddClaim(new Claim("Name", authUser.FirstName + " " + authUser.LastName));
                identity.AddClaim(new Claim("Email", authUser.UserAccount.Email));
                identity.AddClaim(new Claim("Guid", authUser.UniqueKey.ToString()));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "Status", Convert.ToString(authUser.RequestStatus) },
                    { "Name", authUser.FirstName+" "+authUser.LastName},
                    { "Email", authUser.UserAccount.Email},
                    { "Guid", authUser.UniqueKey.ToString()}
                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated();
            }
            else
            {
                context.SetError("Invalid User", "Invalid username or password");
            }
            return;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }


    }
}