﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer.Enums
{
    public enum DepoHareketTipleri
    {
        [Display(Name = "Giriş")]
        Giris = 1,
        [Display(Name = "Çıkış")]
        Cikis
    }
}
