using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer.Enums
{
    public enum Birimler
    {
        [Display(Name = "Adet")]
        Adet = 1,
        [Display(Name = "Kg")]
        Kg,
        [Display(Name = "Koli" )]
        Koli
    }
}
