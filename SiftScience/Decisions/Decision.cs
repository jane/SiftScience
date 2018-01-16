using Newtonsoft.Json;
using SiftScience.Labels;

namespace SiftScience.Decisions
{
    public class Decision
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("entity_type")]
        public EntityType EntityType { get; set; }

        [JsonProperty("abuse_type")]
        public AbuseType AbuseType { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }
    }
}
