using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class Config
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
