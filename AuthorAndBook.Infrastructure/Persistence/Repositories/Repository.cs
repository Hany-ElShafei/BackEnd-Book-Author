using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using AuthorAndBook.Core.Interfeces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

namespace AuthorAndBook.Infrastructure.Persistence.Repositories
{
    public class Repository<T, TGetDTO, TAddDTO> : IRepository<T, TGetDTO, TAddDTO> where T : class
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(TAddDTO dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _dbSet.AddAsync(entity);
            //await SaveChanges();
        }


        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TGetDTO>> GetAllAsync(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes)
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TGetDTO>>(entities);
        }
        public async Task<TGetDTO> GetByIdAsync(int id)
        {
            var entities = await _dbSet.FirstOrDefaultAsync();
            return _mapper.Map<TGetDTO>(entities);
        }

        public async Task<IEnumerable<TGetDTO?>> GetLatestAsync()
        {
            if (typeof(TGetDTO) == typeof(BookDTO))
            {
                var books = await _context.Set<Book>()
                    .OrderByDescending(b => b.PublishedDate)
                    .ToListAsync();

                return _mapper.Map<List<TGetDTO>>(books);
            }

            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<List<TGetDTO>>(entities);
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }
    }
}
