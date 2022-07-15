using phone_book_shared.Helpers.Interface;
using phone_book_shared.Models;

namespace phone_book_shared.Helpers.Implementation
{
    public class PaginationGenerationLinkMetaHelper : IPaginationGenerationLinkMetaHelper
    {
        public PaginationDataModel GenerateLinksAndMeta(int page, int pageSize, int totalRecords, string selfLink)
        {
            var paginationDataModel = new PaginationDataModel();
            paginationDataModel.Links.Self = $"{selfLink}?page={page}&page-size={pageSize}";
            paginationDataModel.Links.Prev = Prev(page, pageSize, selfLink);
            paginationDataModel.Meta.TotalPages = (int)(Math.Ceiling(totalRecords / (double)pageSize));
            paginationDataModel.Meta.TotalRecords = totalRecords;
            paginationDataModel.Links.Next = Next(page, pageSize, selfLink, paginationDataModel.Meta.TotalPages);
            paginationDataModel.Links.First = First(paginationDataModel.Meta.TotalPages, pageSize, selfLink);
            paginationDataModel.Links.Last = Last(paginationDataModel.Meta.TotalPages ?? 0, pageSize, selfLink);

            return paginationDataModel;
        }


        private string Prev(int page, int pageSize, string selfLink)
        {
            if ((page - 1) > 0)
                return $"{selfLink}?page={page - 1}&page-size={pageSize}";

            return null;
        }

        private string Next(int page, int pageSize, string selfLink, int? totalPages)
        {
            if (page < totalPages)
                return $"{selfLink}?page={page + 1}&page-size={pageSize}";

            return null;
        }

        private string First(int? totalPages, int pageSize, string selfLink)
        {

            return $"{selfLink}?page={(totalPages - totalPages) + 1}&page-size={pageSize}";

        }

        private string Last(int totalPages, int pageSize, string selfLink)
        {

            return $"{selfLink}?page={totalPages}&page-size={pageSize}";
        }
    }
}
