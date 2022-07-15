using phone_book_shared.Models;

namespace Angular_phone_book.BusinessLogicLayer.Interface
{
    public interface IBaseBll<TModel>
    {
        public Task<Tuple<List<TModel>, int>> GetPageAsync(PageRequestPayload searchParams);
        public Task<TModel> CreateAsync(TModel model);
        public Task<TModel> UpdateAsync(TModel model);
        public Task<TModel> GetByIdAsync(int Id);
        public Task<TModel> DeleteByIdAsync(int Id);
    }
}
