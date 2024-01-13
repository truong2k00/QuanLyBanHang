using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory
{
    public interface IReponsitory<TEntity,REntity, Bind>
    {
        Task<REntity> Create(Bind ID,TEntity item);
        Task<REntity> Update(Bind ID,TEntity item);
        Task<bool> Delete(Bind ID);
    }
}
