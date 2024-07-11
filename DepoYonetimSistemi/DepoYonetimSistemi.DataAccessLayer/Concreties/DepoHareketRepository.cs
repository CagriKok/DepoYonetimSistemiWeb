using DepoYonetimSistemi.DataAccessLayer.Abstracts;
using DepoYonetimSistemi.DataAccessLayer.DBContext;
using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DepoYonetimSistemi.DataAccessLayer.Concreties
{
    public class DepoHareketRepository : Repository<DepoHareket>, IDepoHareketRepository
    {
        public DepoHareketRepository(AppDbContext context) : base(context)
        {
        }
        public List<DepoHareket> GetBugunkuHareketler()
        {
            var date = DateTime.Now;
            return context.DepoHareketleri
                .Include(x => x.Depo)
                .Include(x => x.MalTur)
                .Where(x => DbFunctions.TruncateTime(x.TarihSaat) == date.Date).ToList();
        }

        public DepoHareket GetItemFull(int id)
          => context.DepoHareketleri
            .Include(x => x.MalTur)
            .Include(x => x.Depo)
            .FirstOrDefault(x => x.Id == id);

        public int GetToplamCikisAdet()
         => context.DepoHareketleri.
            Where(x => x.HareketTipleri == EntityLayer.Enums.DepoHareketTipleri.Cikis).Count();

        public int GetToplamGirisAdet()
         => context.DepoHareketleri.
            Where(x => x.HareketTipleri == EntityLayer.Enums.DepoHareketTipleri.Giris).Count();

        public IEnumerable<DepoHareket> ToListFull()
        => context.DepoHareketleri
            .Include(x => x.MalTur)
            .Include(x => x.Depo)
            .ToList();

        public IEnumerable<DepoHareket> ToListFull(int depoid)
        => context.DepoHareketleri
            .Include(x=> x.MalTur)
            .Include(x => x.Depo)
            .Where(x=> x.DepoId == depoid)
            .ToList();
 
    }
}
