using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class municipios_regiones
    {
        [Key]
        [Column(Order = 1)]
        public int id_regiones { get; set; }
        [Key]
        [Column(Order = 2)]
        public int id_municipio { get; set; }

        public virtual regiones regiones { get; set; }

        public virtual municipios municipio { get; set; }
    }
}