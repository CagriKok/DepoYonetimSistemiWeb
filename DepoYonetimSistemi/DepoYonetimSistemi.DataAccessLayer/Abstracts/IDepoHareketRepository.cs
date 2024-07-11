using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.DataAccessLayer.Abstracts
{
    public interface IDepoHareketRepository : IRepository<DepoHareket>
    {
        DepoHareket GetItemFull(int id);
        IEnumerable<DepoHareket> ToListFull();
        IEnumerable<DepoHareket> ToListFull(int depoid);
        int GetToplamGirisAdet();
        int GetToplamCikisAdet();
        List<DepoHareket> GetBugunkuHareketler();
    }
}
