using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Models
{
    public class municipios
    {
        [Key]
        [Column(Order = 1)]
        public int id_municipio { get; set; }
        public String codigo { get; set; }
        public String nombre { get; set; }

        public bool activo { get; set; }

        public virtual ICollection<municipios_regiones> municipios_regiones { get; set; }
    }
}