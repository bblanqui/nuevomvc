using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class regiones
    {
        [Key]
        [Column(Order = 1)]
        public int id_regiones { get; set; }
        public String codigo { get; set; }
        public String nombre { get; set; }

        public virtual ICollection<municipios_regiones> municipios_regiones { get; set; }
    }
}