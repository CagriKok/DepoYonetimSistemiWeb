using DepoYonetimSistemi.EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetimSistemi.EntityLayer
{
    public class MalTur : BaseModel
    {
        [Display(Name = "Mal Tür Adı :")]
        [Required(ErrorMessage = "Mal Tür Adı Boş Geçilemez")]
        public string Ad { get; set; }
    }
}
