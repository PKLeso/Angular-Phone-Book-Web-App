
using Newtonsoft.Json;

namespace phone_book_shared.Models
{
    public class BaseEntity
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "entryDate")]
        public DateTime EntryDate { get; set; }


        [JsonProperty(PropertyName = "modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
