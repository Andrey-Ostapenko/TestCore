﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.DataAccess.Model;

namespace TestCore.DataAccess.Repositories.Generic.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        ///     Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        ///     Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        ///     Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task InsertAsync(T entity);

        /// <summary>
        ///     Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task UpdateAsync(T entity);

        /// <summary>
        ///     Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task DeleteAsync(T entity);

        /// <summary>
        ///     Delete All entities and specially used for deleting all the PastMedicalPatient
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAllAsync(IEnumerable<T> entity);
    }
}