using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class Contexto : DbContext
    {
        public Contexto(): base("RentaVehiculo")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Vehiculo> Vehiculo { get; set; }
        public BindingList<Tipo> Tipo { get; internal set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}
