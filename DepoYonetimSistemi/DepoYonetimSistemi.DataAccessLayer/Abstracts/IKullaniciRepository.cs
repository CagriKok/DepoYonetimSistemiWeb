using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.DataAccessLayer.Abstracts
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        bool Login(string eposta, string parola);
        Kullanici GetItemWithEPosta(string eposta);
    }
}
