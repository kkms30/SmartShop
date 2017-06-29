using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartShopWebApp.Persistance;
using SmartShopWebApp.Core.GeneratedModels;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SmartShopWebApp.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var id = context.UserName;
                var password = context.Password;

                UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());                            

                Cashier cashier = unitOfWork.Cashiers.GetCashierByCredentials(id, password);

                if (cashier != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, cashier.Name),
                        new Claim("Id", cashier.Id)
                    };

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.OauthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("Invalid grant", "Bad id or password.");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}