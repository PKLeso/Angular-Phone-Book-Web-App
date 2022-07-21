using Microsoft.AspNetCore.Mvc;

namespace phone_book_shared.Models
{
    public class EntryRequestParams
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}
