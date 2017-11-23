using Parcial1_Ap2_EstebanMena.DAL;
using Parcial1_Ap2_EstebanMena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Parcial1_Ap2_EstebanMena.BLL
{
    public class PresupuestoDetalleBLL
    {
        public static bool Guardar(PresupuestoDetalle relacion)
        {
            using (var repositorio = new Repositorio<PresupuestoDetalle>())
            {
                if (repositorio.Buscar(P => P.Id == relacion.Id) == null)
                {
                    return repositorio.Guardar(relacion);
                }
                else
                {
                    //return repositorio.Modificar(presupuestoDetalle);
                    using (var context = new ParcialDb())
                    {
                        context.PresupuestoDetalle.Attach(relacion);
                        context.Entry(relacion).State = System.Data.Entity.EntityState.Modified;
                        return context.SaveChanges() > 0;
                    }
                }
            }
        }

        public static PresupuestoDetalle Buscar(Expression<Func<PresupuestoDetalle, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<PresupuestoDetalle>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static bool Eliminar(PresupuestoDetalle presupuesto)
        {
            using (var repositorio = new Repositorio<PresupuestoDetalle>())
            {
                return repositorio.Eliminar(presupuesto);
            }
        }

        public static List<PresupuestoDetalle> GetList(Expression<Func<PresupuestoDetalle, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<PresupuestoDetalle>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
    }
}