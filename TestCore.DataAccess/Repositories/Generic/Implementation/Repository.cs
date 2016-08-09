using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCore.DataAccess.Model;
using TestCore.DataAccess.Repositories.Generic.Interfaces;

namespace TestCore.DataAccess.Repositories.Generic.Implementation
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        private DbSet<T> _dbSet;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Entities
        /// </summary>
        protected virtual DbSet<T> DbSet => _dbSet ?? (_dbSet = _context.Set<T>());

        /// <summary>
        ///     Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => DbSet;

        /// <summary>
        ///     Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual async Task<T> GetByIdAsync(Guid id) => await DbSet.FirstOrDefaultAsync(arg => arg.Id == id);

        /// <summary>
        ///     Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbSet.Add(entity);

            await _context.SaveChangesAsync();
        }


        /// <summary>
        ///     Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }


        /// <summary>
        ///     Delete All entities and specially used for deleting all the PastMedicalPatient
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAllAsync(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                DbSet.Remove(item);
            }
            await _context.SaveChangesAsync();
        }
    }
}