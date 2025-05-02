using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.Interfeces
{
    public interface IRepository<T , TGetDTO, TAddDTO> where T : class
    {
        Task<IEnumerable<TGetDTO>> GetAllAsync(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task<TGetDTO> GetByIdAsync(int id);
        Task<IEnumerable<TGetDTO?>> GetLatestAsync();
        Task AddAsync(TAddDTO entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChanges();
    }
}
