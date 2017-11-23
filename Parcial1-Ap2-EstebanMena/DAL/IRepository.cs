using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_Ap2_EstebanMena.DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        bool Guardar(TEntity entidad);
        bool Modificar(TEntity entidad);
        bool Eliminar(TEntity entidad);
        TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> criterioBusqueda);
    }
}
