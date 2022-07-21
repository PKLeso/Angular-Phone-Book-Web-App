using Newtonsoft.Json;

namespace phone_book_shared.Models
{
    public class RequestPayload<TDataModel>
    {
        [JsonProperty("data")]
        public TDataModel Data { get; set; }
        [JsonProperty("meta")]
        public ApiRequestMeta Meta { get; set; }
    }
}
