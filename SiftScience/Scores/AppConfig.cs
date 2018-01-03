using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class AppConfig
    {
        [JsonProperty("decision_id")]
        public string DecisionId { get; set; }
        [JsonProperty("buttons")]
        public List<Button> Buttons { get; set; }
    }
}
