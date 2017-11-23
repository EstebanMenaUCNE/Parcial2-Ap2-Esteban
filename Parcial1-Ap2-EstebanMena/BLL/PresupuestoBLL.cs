using Parcial1_Ap2_EstebanMena.DAL;
using Parcial1_Ap2_EstebanMena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Parcial1_Ap2_EstebanMena.BLL
{
    public class PresupuestoBLL
    {
        public static bool Guardar(Presupuesto presupuesto, List<Entidades.PresupuestoDetalle> listaRelaciones)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                if (repositorio.Buscar(P => P.PresupuestoId == presupuesto.PresupuestoId) == null)
                {
                    repositorio.Guardar(presupuesto);
                    bool relacionesGuardadas = true;
                    foreach (var relacion in listaRelaciones)
                    {
                        relacion.PresupuestoId = presupuesto.PresupuestoId;
                        if (!PresupuestoDetalleBLL.Guardar(relacion))
                        {
                            relacionesGuardadas = false;
                        }
                    }
                    return relacionesGuardadas;
                }
                else
                {
                    //return repositorio.Modificar(presupuesto);
                    using (var context = new ParcialDb())
                    {
                        context.Presupuestos.Attach(presupuesto);
                        context.Entry(presupuesto).State = System.Data.Entity.EntityState.Modified;
                        return context.SaveChanges() > 0;
                    }
                }
            }
        }

        public static Presupuesto Buscar(Expression<Func<Presupuesto, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static bool Eliminar(Presupuesto presupuesto)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.Eliminar(presupuesto);
            }
        }

        public static List<Presupuesto> GetList(Expression<Func<Presupuesto, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
    }
}