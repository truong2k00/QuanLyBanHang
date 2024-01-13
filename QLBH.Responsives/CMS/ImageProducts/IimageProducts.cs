using QLBH.Models.DataRequest.Request_Models.Request_ImageProduct;
using QLBH.Models.DataResponse.Response_Models.DataRespon_ImageProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory.CMS.ImageProducts
{
    public interface IimageProducts<TEntity,Bind> : IReponsitory<Request_ImageProduct,Respon_ImageProduct,long>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Bind IDProduct);
        Task<TEntity> GetByIDAsync(Bind ID);
    }
}
