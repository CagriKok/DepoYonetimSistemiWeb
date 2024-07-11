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
    public class DepoHareket : BaseModel
    {
        [ForeignKey(nameof(Depo))]
        [Required(ErrorMessage = "Depo Seçmelisiniz")]
        [Display(Name = "Depo :")]
        public int DepoId { get; set; }
        public Depo Depo { get; set; }

        [ForeignKey(nameof(MalTur))]
        [Required(ErrorMessage = "Mal Türü Seçmelisiniz")]
        [Display(Name = "Mal Tür :")]
        public int MalTurId { get; set; }
        public MalTur MalTur { get; set; }

        [Display(Name = "Hareket Tipi :")]
        public DepoHareketTipleri HareketTipleri { get; set; } = DepoHareketTipleri.Giris;

        [Display(Name = "Tarih :")]
        public DateTime TarihSaat { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Miktarın Girilmesi Zorunludur")]
        [Range(0.0,100000,ErrorMessage = "Miktar 0 ile 100 aralığında olmalıdır")]
        [Display(Name = "Miktar :")]
        public double Miktar { get; set; }

        [Display(Name = "Birim :")]
        public Birimler Birim { get; set; } = Birimler.Adet;

        [Display(Name = "Açıklama :")]
        public string Aciklama { get; set; }
    }
}
