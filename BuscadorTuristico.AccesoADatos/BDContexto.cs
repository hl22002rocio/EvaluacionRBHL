using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ********************************
using Microsoft.EntityFrameworkCore;
using RLCRUD.EntidadesDeNegocio;

namespace RLCRUD.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Contacto> Contacto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-EMGKJOF;Initial Catalog=CRUDRLdb;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"data source=crudrldb.mssql.somee.com;Initial Catalog=crudrldb;User Id=rociocrud; pwd=cuadrosagedrez");

        }
    }
}
