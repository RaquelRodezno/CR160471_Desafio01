using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace CR160471_Desafio01.Models
{
    public class tipocuentabancaria
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string tipocuenta { get; set; }
        

        public Boolean activo { get; set; }
        

        public virtual ICollection<cuentabancaria> Cuentabancarias { get; set; }
    }
}