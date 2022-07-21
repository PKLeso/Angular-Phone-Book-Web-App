using Angular_phone_book.BusinessLogicLayer.Interface;
using Angular_phone_book.Data;
using phone_book_shared.Models;

namespace Angular_phone_book.BusinessLogicLayer.Implementation
{
    public abstract class BaseBll<TModel> : IBaseBll<TModel> where TModel : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseBll(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Task<Tuple<List<TModel>, int>> GetPageAsync(PageRequestPayload searchParams)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> CreateAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> DeleteByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
