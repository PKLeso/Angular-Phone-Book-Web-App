using Newtonsoft.Json;

namespace Angular_phone_book.Models
{
    public class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]

        public int Id { get; set; }
    }
}
