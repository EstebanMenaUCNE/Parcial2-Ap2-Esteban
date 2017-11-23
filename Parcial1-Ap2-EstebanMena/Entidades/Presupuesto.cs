using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1_Ap2_EstebanMena.Entidades
{
    public class Presupuesto
    {
        [Key]
        public int PresupuestoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public Presupuesto()
        {

        }

        public Presupuesto(int presupuestoId, DateTime fecha, string descripcion, double monto)
        {
            PresupuestoId = presupuestoId;
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
        }

    }
}