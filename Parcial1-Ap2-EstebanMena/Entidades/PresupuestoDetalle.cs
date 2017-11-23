using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1_Ap2_EstebanMena.Entidades
{
    public class PresupuestoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public string Descripcion { get; set; }
        public double Meta { get; set; }
        public string Logrado { get; set; }

        public PresupuestoDetalle()
        {

        }

        public PresupuestoDetalle(int id, int presupuestoId, string descripcion, double meta, string logrado)
        {
            Id = id;
            PresupuestoId = presupuestoId;
            Descripcion = descripcion;
            Meta = meta;
            Logrado = logrado;
        }
    }
}