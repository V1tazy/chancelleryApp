using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.Interface
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> items { get; }

        T Get(int id);

        Task<T> GetAsync(int id, CancellationToken cancel);

        T Add(T item);

        Task<T> AddAsync(T item, CancellationToken cancel);

        void Update(T item);

        Task UpdateAsync(T item, CancellationToken cancel);


        void Remove(int id);

        Task RemoveAsync(int id, CancellationToken cancel);

    }
}
