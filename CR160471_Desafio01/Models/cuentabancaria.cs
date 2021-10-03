using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace CR160471_Desafio01.Models
{
    public class cuentabancaria
    {

        [Key]
        public int id { get; set; }

        [ForeignKey("cliente")]
        
        public int idcliente { get; set; }
        public virtual cliente cliente { get; set; }

        [StringLength(50)]
       
        public string modena { get; set; }

        [ForeignKey("tipocuentabancaria")]
        
        public int tipo { get; set; }
        public virtual tipocuentabancaria tipocuentabancaria { get; set; }
        public virtual ICollection<transacciones> transacciones { get; set; }
    }
}