using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepoYonetimSistemi.Web.Models
{
    public class DashBoardModel
    {
        public int DepoAdet { get; set; }
        public double TopGirisAdet { get; set; }
        public double TopCikisAdet { get; set; }

        public List<DepoHareket> BugunHareketleri { get; set; }
    }
}