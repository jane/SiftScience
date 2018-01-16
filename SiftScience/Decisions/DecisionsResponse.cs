using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SiftScience.Decisions
{
    public class DecisionsResponse
    {
        public bool Success { get; set; }

        [JsonProperty("data")]
        public List<Decision> Decisions { get; set; }
    }
}
