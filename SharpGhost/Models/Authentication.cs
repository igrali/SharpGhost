using Newtonsoft.Json;

namespace SharpGhost.Models
{
    public class Authentication
    {
        /// <summary>
        /// Access token
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Time until the access token expires, expressed in seconds
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Type of access token
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    }
}
