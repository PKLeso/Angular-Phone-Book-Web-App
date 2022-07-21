using Angular_phone_book.BusinessLogicLayer.Interface;
using Angular_phone_book.Data;
using phone_book_shared.Entities;
using phone_book_shared.Models;
using phone_book_shared.Services.Interface.DataAccess;

namespace Angular_phone_book.BusinessLogicLayer.Implementation
{
    public class PhonebookBll : BaseBll<PhoneBook>, IPhonebookBll
    {
        protected readonly ApplicationDbContext _dataAccessLayer;
        public PhonebookBll(ApplicationDbContext dataAccessLayer) : base(dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public Task<Tuple<List<PhoneBook>, int>> GetEntryByNameAsync(EntryRequestParams requestParams)
        {
            throw new NotImplementedException();
        }
    }
}
