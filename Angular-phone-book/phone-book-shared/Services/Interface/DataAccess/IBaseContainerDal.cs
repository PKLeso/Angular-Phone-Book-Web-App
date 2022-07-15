using System.Linq.Expressions;

namespace phone_book_shared.Services.Interface.DataAccess
{
    public interface IBaseContainerDal<T>
    {
        Task<T> AddItemAsync(T entity);
        Task<T> RemoveItemAsync(string id);
        Task<T> GetItemByIdAsync(string id);
        Task<T> UpdateItemAsync(T entity);
        Task<Tuple<List<T>, int>> GetPageAsync(int page, int pageSize, Expression<Func<T, bool>> lamda = null, 
                                                    string sortColumn = null, bool desc = false);
        Task<T> GetItemWhereAsync(Expression<Func<T, bool>> lamda);
        Task<List<T>> GetItemsWhereAsync(Expression<Func<T, bool>> lamda);
    }
}
