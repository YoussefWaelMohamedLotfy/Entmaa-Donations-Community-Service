using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a single instance of an entity
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> The entity found, or null </returns>
        public T Get(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        /// <summary>
        /// Gets all instances of an entity
        /// </summary>
        /// <returns> All instances </returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Finds a single or multiple instances of an entity satisfing a condition
        /// </summary>
        /// <param name="predicate"> Lambda Expression for condition of searching </param>
        /// <returns> A single or collection of entities </returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Adds a single entity to the context
        /// </summary>
        /// <param name="item"> The entity to be added </param>
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        /// <summary>
        /// Adds a collection of entities to the context
        /// </summary>
        /// <param name="item"> The entities to be added </param>
        public void AddRange(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);
        }

        /// <summary>
        /// Deletes a single entity from the context
        /// </summary>
        /// <param name="item"> The entity to be deleted </param>
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        /// <summary>
        /// Deletes a collection of entities from the context
        /// </summary>
        /// <param name="item"> The entities to be deleted </param>
        public void DeleteRange(IEnumerable<T> items)
        {
            _context.Set<T>().RemoveRange(items);
        }

    }
}