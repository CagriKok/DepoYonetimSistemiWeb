using DepoYonetimSistemi.DataAccessLayer.Abstracts;
using DepoYonetimSistemi.DataAccessLayer.Concreties;
using DepoYonetimSistemi.DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext context;
        private IDepoHareketRepository _depohareketRepository;
        private IKullaniciRepository _kullaniciRepository;
        private IMalTurRepository _malTurRepository;
        private IDepoRepository _depoRepository;


        public IDepoHareketRepository DepoHareketRepository
        {
            get
            {
                if (_depohareketRepository == null)
                    _depohareketRepository = new DepoHareketRepository(context);
                return _depohareketRepository;
            }
        }

        public IKullaniciRepository KullaniciRepository
        {
            get
            {
                if (_kullaniciRepository == null)
                    _kullaniciRepository = new KullaniciRepository(context);
                return _kullaniciRepository;
            }
        }
        public IMalTurRepository MalTurRepository
        {
            get
            {
                if(_malTurRepository == null)
                    _malTurRepository = new MalTurRepository(context); 
                return _malTurRepository;
            }
        }

        public IDepoRepository DepoRepository
        {
            get
            {
                if( _depoRepository == null)
                    _depoRepository = new DepoRepository(context);
                return _depoRepository;
            }
        }
        public UnitOfWork() 
         => context = new AppDbContext();

        public int SaveChanges()
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                int count = context.SaveChanges();
                transaction.Commit();
                return count;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            _malTurRepository?.Dispose();
            _depoRepository?.Dispose();
            _depohareketRepository?.Dispose();
            _kullaniciRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
