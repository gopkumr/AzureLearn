using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System.Threading;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class MyTokenCredential : TokenCredential
    {

        private ITokenAcquisition _tokenAcquisition;
        private AuthenticationResult _authenticationResult;

        /// <summary>
        /// Constructor from an ITokenAcquisition service.
        /// </summary>
        /// <param name="tokenAcquisition">Token acquisition.</param>
        public MyTokenCredential(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public MyTokenCredential(AuthenticationResult result)
        {
            _authenticationResult = result;
        }

        /// <inheritdoc/>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (_authenticationResult == null)
            {
                _authenticationResult = _tokenAcquisition.GetAuthenticationResultForUserAsync(requestContext.Scopes)
                    .GetAwaiter()
                    .GetResult();
            }

            return new AccessToken(_authenticationResult.AccessToken, _authenticationResult.ExpiresOn);
        }

        /// <inheritdoc/>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (_authenticationResult == null)
                _authenticationResult = await _tokenAcquisition.GetAuthenticationResultForUserAsync(requestContext.Scopes).ConfigureAwait(false);

            return new AccessToken(_authenticationResult.AccessToken, _authenticationResult.ExpiresOn);
        }

    }
}
