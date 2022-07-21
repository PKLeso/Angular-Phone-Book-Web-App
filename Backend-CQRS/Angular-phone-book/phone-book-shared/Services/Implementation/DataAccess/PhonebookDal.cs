using Microsoft.EntityFrameworkCore;
using phone_book_shared.Entities;
using phone_book_shared.Services;
using phone_book_shared.Services.Interface.DataAccess;

namespace phone_book_shared.Services.Implementation.DataAccess
{
    public class PhonebookDal : BaseContainerDal<PhoneBook>, IPhonebookDal
    {
        private ApplicationDbContext _dataAccess;
        public PhonebookDal(ApplicationDbContext dataAccess) : base(dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<PhoneBook>> GetPhonebookEntryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException();
            }

            return await _dataAccess.Set<PhoneBook>().Where(x => x.Name == name).ToListAsync();
        }

    }
}
