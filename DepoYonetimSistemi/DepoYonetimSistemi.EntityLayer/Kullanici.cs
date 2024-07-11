using DepoYonetimSistemi.EntityLayer.Base;
using DepoYonetimSistemi.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer
{
    public class Kullanici : BaseModel
    {
        [Display(Name = "Adı :")]
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez")]
        public string Ad { get; set; }

        [Display(Name = "Soyadı :")]
        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez")]
        public string Soyad { get; set; }

        [NotMapped]
        public string AdSoyad { get { return Ad + " " + Soyad; }}

        [Display(Name = "EPosta :")]
        [Required(ErrorMessage = "EPosta Alanı Boş Geçilemez")]
        public string EPosta { get; set; }

        [Display(Name = "Parola :")]
        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez")]
        public string Parola { get; set; }

        [Display(Name = "Parola Tekrar :")]
        [Required(ErrorMessage = "Parola Tekrar Alanı Boş Geçilemez")]
        [Compare(nameof(Parola),ErrorMessage = "Parola Tekrarı ile parola aynı olmalıdır")]
        [NotMapped]
        public string ParolaTekrar { get; set; }

        [Display(Name = "Yetki :")]
        public KullaniciYetkiler Yetkiler { get; set; } = KullaniciYetkiler.User;
    }
}
