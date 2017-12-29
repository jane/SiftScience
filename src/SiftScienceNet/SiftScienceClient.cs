using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiftScienceNet.Events;
using SiftScienceNet.Scores;
using SiftScienceNet.Labels;
using System.Dynamic;

namespace SiftScienceNet
{
    public interface ISiftScienceClient
    {
        Task<ResponseStatus> CustomEvent(string userId, string type, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> CreateOrder(Order order, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> UpdateOrder(Order order, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> UpdateOrderStatus(UpdateOrderStatus status, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> Transaction(Transaction transaction, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> CreateAccount(Account account, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> UpdateAccount(Account account, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> AddItemToCart(string userId, Item item, dynamic customFields = null, string sessionId = "", ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> RemoveItemFromCart(string userId, Item item, int quantity, dynamic customFields = null, string sessionId = "", ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> SubmitReview(Review review, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> CreateContent(Content content, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> UpdateContent(Content content, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> SendMessage(string userId, string recipientUserId, string subject = "", string content = "", int? time = null, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> Login(string userId, string sessionId, bool success, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> Logout(string userId, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> LinkSessionToUser(string userId, string sessionId, dynamic customFields = null, ReturnType returnType = ReturnType.None);
        Task<ResponseStatus> Label(string userId, bool isBad, AbuseType abuseType, string description = "", string analyst = "", string source = "");
        Task<ScoreResponse> GetSiftScore(string userId);
        Task<LegacyScoreResponse> GetSiftLegacyScore(string userId);
    }

    /// <summary>
    /// see:https://siftscience.com/docs/rest-api
    /// </summary>
    public class SiftScienceClient : ISiftScienceClient
    {
        private static string _apiKey;

        public SiftScienceClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        #region Events

        public async Task<ResponseStatus> CustomEvent(string userId, string type, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();
	        if (customFields != null)
	        {
		        json = GetJsonObject(customFields);
	        }

			json.Add("$api_key", _apiKey);
            json.Add("$type", type);
            json.Add("$user_id", userId);
            json.Add("$time", DateTime.UtcNow.ToUnixTimestamp());

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }


        public async Task<ResponseStatus> CreateOrder(Order order, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
	        var json = GetJsonObject(order);

			json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_order");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateOrder(Order order, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(order);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_order");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateOrderStatus(UpdateOrderStatus order, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(order);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$order_status");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        private void AddCustomFields(dynamic customFields, JObject json, ReturnType returnType = ReturnType.None)
        {
            if (customFields != null)
            {
                JObject o = GetJsonObject(customFields);
                foreach (var value in o.Properties())
                {
                    json.Add(value);
                }
            }
        }

        public async Task<ResponseStatus> Transaction(Transaction transaction, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(transaction);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$transaction");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> CreateAccount(Account account, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(account);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_account");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Chargeback(Chargeback chargeback, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(chargeback);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$chargeback");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateAccount(Account account, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(account);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_account");
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> AddItemToCart(string userId, Item item, dynamic customFields = null, string sessionId = "", ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$add_item_to_cart");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);

			AddCustomFields(customFields, json);

            var jObjectItem = GetJsonObject(item);
            json.Add("$item", jObjectItem);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> RemoveItemFromCart(string userId, Item item, int quantity, dynamic customFields = null, string sessionId = "", ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$remove_item_from_cart");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);
            json.Add("$quantity", quantity);

			AddCustomFields(customFields, json);

            var jObjectItem = GetJsonObject(item);
            json.Add("$item", jObjectItem);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> SubmitReview(Review review, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(review);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$submit_review");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> CreateContent(Content content, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(content);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_content");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateContent(Content content, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = GetJsonObject(content);
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_content");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> FlagContent(string userId, string contentId, string flagedBy, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            var json = new JObject();

            json.Add("$type", "$flag_content");
            json.Add("$api_key", _apiKey);
            json.Add("$user_id", userId);
            json.Add("$content_id", contentId);
            json.Add("$flagged_by", flagedBy);

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> SendMessage(string userId, string recipientUserId, string subject = "", string content = "", int? time = null, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$send_message");
            json.Add("$user_id", userId);
            json.Add("$recipient_user_id", recipientUserId);

            if (!String.IsNullOrEmpty(subject))
                json.Add("$subject", subject);

            if (!String.IsNullOrEmpty(content))
                json.Add("$content", content);

            if (time.HasValue)
                json.Add("$time", time.Value);

	        AddCustomFields(customFields, json);

			return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Login(string userId, string sessionId, bool success, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$login");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);
            json.Add("$login_status", success ? "$success" : "$failure");

	        AddCustomFields(customFields, json);

			return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Logout(string userId, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$logout");
            json.Add("$user_id", userId);

	        AddCustomFields(customFields, json);

			return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> LinkSessionToUser(string userId, string sessionId, dynamic customFields = null, ReturnType returnType = ReturnType.None)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$link_session_to_user");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);

	        AddCustomFields(customFields, json);

			return await PostEvent(json.ToString(), returnType).ConfigureAwait(false);
        }

        private async Task<ResponseStatus> PostEvent(string jsonContent, ReturnType returnType)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

	        string endpoint;
	        switch (returnType)
	        {
		        case ReturnType.None:
			        endpoint = Globals.EventsEndpoint;
					break;
		        case ReturnType.Score:
			        endpoint = Globals.EventsWithScoreEndpoint;
			        break;
		        case ReturnType.WorkflowStatus:
			        endpoint = Globals.EventsWithWorkflowStatusEndpoint;
			        break;
		        default:
			        throw new ArgumentOutOfRangeException(nameof(returnType), returnType, null);
	        }
            HttpResponseMessage response = await client.PostAsync(endpoint, new StringContent(jsonContent, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var siftResponse = JsonConvert.DeserializeObject<SiftResponse>(response.Content.ReadAsStringAsync().Result);

            return new ResponseStatus { Success = response.IsSuccessStatusCode, SiftResponse = siftResponse, StatusCode = (int)response.StatusCode };
        }

	    private JObject GetJsonObject(object o)
	    {
		    return JObject.FromObject(o, JsonSerializer.Create(new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
		}

        #endregion

        #region Labels

        public async Task<ResponseStatus> Label(string userId, bool isBad, AbuseType abuseType, string description = "", string analyst = "", string source = "")
        {
            var baseObject = new ExpandoObject() as IDictionary<string, Object>;
            baseObject.Add("$abuse_type", abuseType);

            baseObject.Add("$api_key", _apiKey);
            baseObject.Add("$is_bad", isBad);

            if (!String.IsNullOrEmpty(analyst))
            {
                baseObject.Add("$analyst", analyst);
            }

            if (!String.IsNullOrEmpty(source))
            {
                baseObject.Add("$source", source);
            }

            if (!String.IsNullOrEmpty(description))
            {
                baseObject.Add("$description", description);
            }

            var json = JsonConvert.SerializeObject(baseObject, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsync(string.Format(Globals.LabelsEndpoint, Uri.EscapeDataString(userId)), new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseStatus { Success = true, StatusCode = (int)HttpStatusCode.OK };
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonConvert.DeserializeObject<SiftResponse>(response.Content.ReadAsStringAsync().Result);

                return new ResponseStatus { Success = false, SiftResponse = error, StatusCode = (int)HttpStatusCode.BadRequest };
            }


            return new ResponseStatus { Success = false, StatusCode = (int)response.StatusCode };
        }

        #endregion

        #region Scores

        public async Task<ScoreResponse> GetSiftScore(string userId)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(string.Format(Globals.ScoresEndpoint, Uri.EscapeDataString(userId), _apiKey)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ScoreResponse>(json);
            }

            return new ScoreResponse { Status = (int)response.StatusCode };
        }

        #endregion

        #region LegacyScore

        public async Task<LegacyScoreResponse> GetSiftLegacyScore(string userId)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(string.Format(Globals.LegacyScoreEndpoint, Uri.EscapeDataString(userId), _apiKey)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<LegacyScoreResponse>(json);
            }

            return new LegacyScoreResponse { Status = (int)response.StatusCode };
        }

        #endregion
    }
}