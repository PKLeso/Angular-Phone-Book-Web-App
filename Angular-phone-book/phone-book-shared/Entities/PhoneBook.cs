
using Newtonsoft.Json;
using phone_book_shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phone_book_shared.Entities
{
    public class PhoneBook : BaseEntity
    {

        [JsonProperty(PropertyName = "name")]
        [Column(TypeName = "NVARCHAR(100)")]
        [Required]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "entries")]
        [Required]
        public List<Entry> Entries { get; set; }
    }
}
