using DepoYonetimSistemi.DataAccessLayer.Abstracts;
using DepoYonetimSistemi.DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DepoYonetimSistemi.DataAccessLayer.Concreties
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        public Repository(AppDbContext context) => this.context = context;

        public void Add(T item)
            => context.Set<T>().Add(item);

        public IEnumerable<T> GetAll()
            => context.Set<T>().ToList();

        public void Delete(T item)
        {
            if (context.Entry<T>(item).State == EntityState.Detached)
                context.Set<T>().Attach(item);
            context.Entry<T>(item).State = EntityState.Deleted;
        }
        public void Delete(int id)
        {
            Delete(GetItem(id));
        }
        public int GetCount()
            => context.Set<T>().Count();

        public T GetItem(int id)
            => context.Set<T>().Find(id);

        public void Update(T item)
        {
            if(context.Entry<T>(item).State == EntityState.Detached)
                context.Set<T>().Attach(item);
            context.Entry<T>(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
