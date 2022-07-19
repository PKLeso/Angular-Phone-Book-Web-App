
using Default_WebApi.BusinessLogicLayer.Interface;
using LinqKit;
using phone_book_shared.Entities;
using phone_book_shared.Models;
using phone_book_shared.Services;
using phone_book_shared.Services.Interface.DataAccess;
using System.Linq.Expressions;

namespace Default_WebApi.BusinessLogicLayer.Implementation
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
            Expression<Func<PhoneBook, bool>> lamda = PredicateBuilder.New<PhoneBook>(true);

            throw new NotImplementedException();
        }
    }
}
