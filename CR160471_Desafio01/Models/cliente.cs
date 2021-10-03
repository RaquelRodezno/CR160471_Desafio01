
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace CR160471_Desafio01.Models
{
    public class cliente
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]

        public string nombres { get; set; }

        [StringLength(50)]
        public string primerapellido { get; set; }

        [StringLength(50)]
        public string segundoapellido { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no cumple con el formato completo")]
        public string correo { get; set; }

        public virtual ICollection<cuentabancaria> cuentabancaria { get; set; }
    }
}