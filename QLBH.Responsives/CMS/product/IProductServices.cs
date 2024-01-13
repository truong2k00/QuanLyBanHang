using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Commons.Common_Page;
using QLBH.Models.DataRequest;
using QLBH.Models.DataRequest.Request_Models.Request_product;
using QLBH.Models.DataResponse.Response_Models.DataResponse_product;
using QLBH.Models.Entitis;
using QLPT2.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory.CMS.product
{
    public interface IProductServices<TEntity, Base> : IReponsitory<Request_Product, DataResponse_Product, int>
    {

        Task<DataResponse_Product> Create(Request_Product item,RequestFiles file);
        Task<PageResult<TEntity>> GetAll(Pagination pagination, string KeyWord);
        Task<TEntity> GetByID(Base ID);
        Task<string> Get();
    }
}
