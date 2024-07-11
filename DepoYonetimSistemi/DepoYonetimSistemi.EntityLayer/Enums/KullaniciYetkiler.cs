using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer.Enums
{
    public enum KullaniciYetkiler
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "DepoSorumlusu")]
        User
    }
}
