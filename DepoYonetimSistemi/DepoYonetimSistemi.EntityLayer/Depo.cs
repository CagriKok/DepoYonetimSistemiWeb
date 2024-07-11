using DepoYonetimSistemi.EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer
{
    public class Depo : BaseModel
    {
        [Display(Name = "Depo Adı :")]
        [Required(ErrorMessage = "Depo Ad Alanı Boş Geçilemez")]
        public string Ad { get; set; }
    }
}
