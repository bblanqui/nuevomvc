using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace mvc.Models
{
    public class contextodb: DbContext
    {
        public DbSet<regiones> regiones { get; set; }
        public DbSet<municipios> municipios { get; set; }
        public DbSet<municipios_regiones> municipios_regiones { get; set; }
    }
}