

using phone_book_shared.Models;

namespace phone_book_shared.Helpers.Interface
{
    public interface IPaginationGenerationLinkMetaHelper
    {
        public PaginationDataModel GenerateLinksAndMeta(int page, int pageSize, int totalRecords, string selfLink);
    }
}
