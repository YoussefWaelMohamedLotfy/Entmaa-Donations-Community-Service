using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int ID);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T item);
        void AddRange(IEnumerable<T> items);
        
        void Delete(T item);
        void DeleteRange(IEnumerable<T> items);
    }
}
