namespace phone_book_shared.Models
{
    public class PaginationDataModel
    {
        public ApiReponseLink Links { get; set; }
        public ApiReponseMeta Meta { get; set; }

        public PaginationDataModel()
        {
            Links = new ApiReponseLink();
            Meta = new ApiReponseMeta();
        }
    }
}
