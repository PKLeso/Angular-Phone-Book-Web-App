using Microsoft.EntityFrameworkCore;
using phone_book_shared.Entities;
using phone_book_shared.Models;
using phone_book_shared.Services.DbContext;
using phone_book_shared.Services.Interface.DataAccess;
using System.Linq.Expressions;

namespace phone_book_shared.Services.Implementation.DataAccess
{
    public class BaseContainerDal<T> : IBaseContainerDal<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseContainerDal(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<T> AddItemAsync(T entity)
        {
            entity.EntryDate = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetItemByIdAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity == null)
            {
                // log an error and return not found error
                return null;
            }

            return entity;
        }

        public Task<List<T>> GetItemsWhereAsync(Expression<Func<T, bool>> lamda)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetItemWhereAsync(Expression<Func<T, bool>> lamda)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> GetPageAsync(int page, int pageSize, Expression<Func<T, bool>> lamda = null, string sortColumn = null, bool desc = false)
        {
            throw new NotImplementedException();
        }

        public async Task<T> RemoveItemAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                // log an error and return not found error
                return null;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateItemAsync(T entity)
        {
            if(!await EntityExists(entity.Id))
            {
                // log error and return back cannot update record
                return null;
            }

            entity.ModifiedDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        private async Task<bool> EntityExists(int id)
        {
            return await _context.Set<T>().AnyAsync(x => x.Id == id);
        }
    }
}
