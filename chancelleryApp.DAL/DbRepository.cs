using chancelleryApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chancelleryApp.DAL.Entityes.Base;
using chancelleryApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace chancelleryApp.DAL
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly chancelleryContext _db;
        private readonly DbSet<T> _Set;

        public bool AutoSaveChages { get; set; }


        public virtual IQueryable<T> items => _Set;

        public T Add(T item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State = EntityState.Added;

            if (AutoSaveChages)
            {
                _db.SaveChanges();
            }

            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel)
        {
            if(item is null) throw new ArgumentNullException( nameof(item));


            _db.Entry(item).State = EntityState.Added;

            if (AutoSaveChages) {
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            }

            return item;
        }

        public T Get(int id) => items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancel) => await items
            .SingleOrDefaultAsync(item => item.Id == id, cancel)
            .ConfigureAwait(false);

        public void Remove(int id)
        {
            _db.Remove(new T { Id = id});

            if (AutoSaveChages)
            {
                _db.SaveChanges();
            }

        }

        public async Task RemoveAsync(int id, CancellationToken cancel)
        {
            _db.Remove(new T {Id = id});

            if (AutoSaveChages) 
                await _db.SaveChangesAsync(cancel).ConfigureAwait (false);
        }

        public void Update(T item)
        {
            if(item is null) throw new ArgumentException( nameof(item));

            _db.Entry(item).State = EntityState.Modified;

            if (AutoSaveChages)
                _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancel)
        {
            if(item is null) throw new ArgumentException(nameof(item));

            _db.Entry(item).State = EntityState.Modified;
            if(AutoSaveChages)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
