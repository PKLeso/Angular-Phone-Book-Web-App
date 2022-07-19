using System.Linq.Expressions;

namespace phone_book_shared.Services.Interface.DataAccess
{
    public interface IBaseContainerDal<TModel>
    {
        Task<TModel> AddItemAsync(TModel entity);
        Task<TModel> RemoveItemAsync(string id);
        Task<TModel> GetItemByIdAsync(string id);
        Task<TModel> UpdateItemAsync(TModel entity);
        Task<Tuple<List<TModel>, int>> GetPageAsync(int page, int pageSize, Expression<Func<TModel, bool>> lamda = null, string sortColumn = null, bool desc = false);
        Task<TModel> GetItemWhereAsync(Expression<Func<TModel, bool>> lamda);
        Task<List<TModel>> GetItemsWhereAsync(Expression<Func<TModel, bool>> lamda);
    }
}
