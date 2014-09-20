using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SharpGhost.Models;

namespace SharpGhost
{
    public class GhostClient
    {
        #region internal api strings

        private readonly string authenticationRoute = "authentication/token";
        private readonly string baseUrlStringFormat = "{0}/ghost/api/v0.1/";

        #endregion

        #region data

        private string baseUrl;

        #endregion

        #region constructors

        /// <summary>
        /// Creates a new instance of <see cref="GhostClient" /> class
        /// </summary>
        /// <param name="domain">Domain of the Ghost blog. Must begin with http:// or https://.</param>
        /// <param name="username">User's username.</param>
        /// <param name="password">User's password.</param>
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.ArgumentException" />
        /// <exception cref="SharpGhost.GhostException" />
        public GhostClient(string domain)
        {
            if (String.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException(domain);
            }

            if (!domain.StartsWith("http://") && !domain.StartsWith("https://"))
            {
                throw new ArgumentException("Domain format must start with http:// or https://");
            }

            this.baseUrl = String.Format(this.baseUrlStringFormat, domain);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Authenticate user using username and password
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        /// <returns>Returns <see cref="Authentication" /> object</returns>
        /// <exception cref="System.ArgumentNullException" />
        public async Task<Authentication> AuthenticateWithPasswordAsync(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(username);
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(password);
            }

            FormUrlEncodedContent content = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"), 
                    new KeyValuePair<string, string>("client_id", "ghost-admin"),
                    new KeyValuePair<string, string>("username", username), 
                    new KeyValuePair<string, string>("password", password) 
                }
            );

            string requestUrl = this.baseUrl + this.authenticationRoute;

            GhostHttpClient ghostHttpClient = new GhostHttpClient();
            Authentication ghostResponse = null;

            try
            {
                ghostResponse = await ghostHttpClient.PostAsync<Authentication>(requestUrl, content);
            }
            catch (AggregateException aggregateException)
            {
                if (aggregateException.InnerExceptions.Count > 0)
                {
                    throw aggregateException.InnerExceptions[0];
                }
                else
                {
                    throw;
                } 
            }
            catch (Exception )
            {
                throw;
            }

            return ghostResponse;
        }

        #endregion
    }
}
