using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.DataAccessLayer.Abstracts
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        int GetCount();
        T GetItem(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
    }
}
