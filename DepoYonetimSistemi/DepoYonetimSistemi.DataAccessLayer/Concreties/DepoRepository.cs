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
    public class DepoRepository : Repository<Depo>, IDepoRepository
    {
        public DepoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
