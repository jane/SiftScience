using SiftScience.Scores;
using Newtonsoft.Json;

namespace SiftScience
{
    public class SiftResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("score_response")]
        public ScoreResponse ScoreResponse { get; set; }

        public override string ToString()
        {
            return $"{Status}: {ErrorMessage}";
        }
    }
}