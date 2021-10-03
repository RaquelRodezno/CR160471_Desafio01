using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace CR160471_Desafio01.Models
{
    public class transacciones
    {
        [Key]
        public int id { get; set; }

        public double monto { get; set; }
        

        public Boolean estado { get; set; }


       [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " {0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechatransaccion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " {0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaaplicacion { get; set; }

        [ForeignKey("tipotransaccion")]
        
        public int tipotrans { get; set; }
        public virtual tipotransaccion tipotransaccion { get; set; }

        [ForeignKey("cuentabancaria")]
        
        public int idcuentabancaria { get; set; }

        public virtual cuentabancaria cuentabancaria { get; set; }
    }
}