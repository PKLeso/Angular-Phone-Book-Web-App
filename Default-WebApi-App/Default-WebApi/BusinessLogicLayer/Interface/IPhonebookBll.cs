using phone_book_shared.Entities;
using phone_book_shared.Models;

namespace Default_WebApi.BusinessLogicLayer.Interface
{
    public interface IPhonebookBll: IBaseBll<PhoneBook>
    {
        Task<Tuple<List<PhoneBook>, int>> GetEntryByNameAsync(EntryRequestParams requestParams);
    }
}
