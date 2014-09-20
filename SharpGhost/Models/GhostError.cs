using Newtonsoft.Json;

namespace SharpGhost.Models
{
    public class GhostError
    {
        [JsonProperty(PropertyName = "message")]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string ErrorType { get; set; }
    }
}
