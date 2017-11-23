using Parcial1_Ap2_EstebanMena.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parcial1_Ap2_EstebanMena.DAL
{
    public class ParcialDb : DbContext
    {
        public ParcialDb() : base("ConStr")
        {

        }

        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<PresupuestoDetalle> PresupuestoDetalle { get; set; }

    }
}