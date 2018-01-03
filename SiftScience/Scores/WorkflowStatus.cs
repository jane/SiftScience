using System.Collections.Generic;
using SiftScience.Labels;
using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class WorkflowStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("config_display_name")]
        public string ConfigDisplayName { get; set; }

        [JsonProperty("abuse_type")]
        public AbuseType AbuseType { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }

        [JsonProperty("history")]
        public List<HistoryItem> History { get; set; }
    }
}
