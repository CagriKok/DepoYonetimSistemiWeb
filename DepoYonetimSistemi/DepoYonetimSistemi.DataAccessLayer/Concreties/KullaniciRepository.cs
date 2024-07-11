using DepoYonetimSistemi.DataAccessLayer.Abstracts;
using DepoYonetimSistemi.DataAccessLayer.DBContext;
using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.DataAccessLayer.Concreties
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici GetItemWithEPosta(string eposta)
            => context.Set<Kullanici>().FirstOrDefault(x => x.EPosta.ToLower() == eposta.ToLower());

        public bool Login(string eposta, string parola)
        {
           Kullanici user = context.Set<Kullanici>().FirstOrDefault(x => x.EPosta.ToLower() == eposta.ToLower() && x.Parola.ToLower() == parola);
            return user == null ? false : true;
        }
        
    }
}
