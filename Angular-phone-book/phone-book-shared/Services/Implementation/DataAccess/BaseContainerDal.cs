using Microsoft.EntityFrameworkCore;
using phone_book_shared.Entities;
using phone_book_shared.Models;
using phone_book_shared.Services;
using phone_book_shared.Services.Interface.DataAccess;
using System.Linq.Expressions;

namespace phone_book_shared.Services.Implementation.DataAccess
{
    public class BaseContainerDal<TModel> : IBaseContainerDal<TModel> where TModel : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseContainerDal(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<TModel> AddItemAsync(TModel entity)
        {
            entity.EntryDate = DateTime.Now;
            await _context.Set<TModel>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TModel> GetItemByIdAsync(string id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id);
            if(entity == null)
            {
                // log an error and return not found error
                return null;
            }

            return entity;
        }

        public Task<List<TModel>> GetItemsWhereAsync(Expression<Func<TModel, bool>> lamda)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetItemWhereAsync(Expression<Func<TModel, bool>> lamda)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<TModel>, int>> GetPageAsync(int page, int pageSize, Expression<Func<TModel, bool>> lamda = null, string sortColumn = null, bool desc = false)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> RemoveItemAsync(string id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id);
            if (entity == null)
            {
                // log an error and return not found error
                return null;
            }

            _context.Set<TModel>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TModel> UpdateItemAsync(TModel entity)
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
            return await _context.Set<TModel>().AnyAsync(x => x.Id == id);
        }
    }
}
