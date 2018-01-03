namespace SiftScience
{
    public class Globals
    {
        public const string Authority = "https://api.siftscience.com";
        public const string EventsEndpoint = Authority + "/v204/events";
        public const string EventsWithScoreEndpoint = EventsEndpoint + "?return_score=true";
        public const string EventsWithAccountTakeoverWorkflowEndpoint = EventsEndpoint + "?return_workflow_status=true&abuse_types=account_takeover";
        public const string EventsWithPaymentAbuseWorkflowEndpoint = EventsEndpoint + "?return_workflow_status=true&abuse_types=payment_abuse";
        public const string LabelsEndpoint = Authority + "/v204/users/{0}/labels";
        public const string ScoresEndpoint = Authority + "/v204/score/{0}/?api_key={1}";
        public const string LegacyScoreEndpoint = Authority + "/v204/score/{0}/?abuse_types=legacy&api_key={1}";
    }
}
