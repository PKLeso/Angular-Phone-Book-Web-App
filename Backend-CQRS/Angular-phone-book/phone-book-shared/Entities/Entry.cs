
using Newtonsoft.Json;
using phone_book_shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phone_book_shared.Entities
{
    public class Entry : BaseEntity
    {

        [JsonProperty(PropertyName = "name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "phoneNumber")]
        [Column(TypeName = "INTEGER(10)")]
        [Required]
        public int PhoneNumber { get; set; }
    }
}
