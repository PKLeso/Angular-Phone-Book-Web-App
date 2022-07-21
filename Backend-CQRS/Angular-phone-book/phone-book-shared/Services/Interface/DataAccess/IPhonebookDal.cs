using phone_book_shared.Entities;

namespace phone_book_shared.Services.Interface.DataAccess
{
    public interface IPhonebookDal : IBaseContainerDal<PhoneBook>
    {
        Task<List<PhoneBook>> GetPhonebookEntryByName(string name);
    }
}
