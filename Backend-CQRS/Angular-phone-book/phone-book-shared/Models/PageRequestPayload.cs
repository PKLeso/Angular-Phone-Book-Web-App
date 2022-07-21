using Microsoft.AspNetCore.Mvc;

namespace phone_book_shared.Models
{
    public class PageRequestPayload
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;


        [FromQuery(Name = "page-size")]
        public int PageSize { get; set; } = 25;


        [FromQuery(Name = "sort-property-name")]
        public string SortPropertyName { get; set; }


        [FromQuery(Name = "sort-direction")]
        public string SortDirection { get; set; } = "asc";
    }
}
