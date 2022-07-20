
using Default_WebApi.BusinessLogicLayer.Interface;
using phone_book_shared.Models;
using phone_book_shared.Services;

namespace Default_WebApi.BusinessLogicLayer.Implementation
{
    public abstract class BaseBll<TModel> : IBaseBll<TModel> where TModel : BaseEntity
    {
        protected readonly ApplicationDbContext _dataAccess;

        public BaseBll(ApplicationDbContext context)
        {
            _dataAccess = context;
        }

        public async Task<Tuple<List<TModel>, int>> GetPageAsync(PageRequestPayload searchParams)
        {
            return await this._dataAccess.GetPageAsync(searchParams.Page, searchParams.PageSize, null, searchParams.SortPropertyName, searchParams.SortDirection.ToLower() == "desc");
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
