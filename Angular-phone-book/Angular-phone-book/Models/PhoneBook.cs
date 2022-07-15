using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_phone_book.Models
{
    public class PhoneBook
    {
        [Key]
        public int PhoneBookId { get; set; }


        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }


        [Column(TypeName = "INTEGER(10)")]
        public List<Entry> Entries { get; set; }
    }
}
