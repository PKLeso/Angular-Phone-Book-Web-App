namespace phone_book_shared.Models
{
    public class ResponsePayload<TResponseDataModel>
    {
        public TResponseDataModel Data { get; set; }
        public ApiReponseLink Links { get; set; }

        public ApiReponseMeta Meta { get; set; }
        public ResponsePayload()
        {
            Links = new ApiReponseLink();
            Meta = new ApiReponseMeta();
        }
    }
}
