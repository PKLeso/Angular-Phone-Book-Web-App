using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_phone_book.Models
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public int PhoneNumber { get; set; }
    }
}
