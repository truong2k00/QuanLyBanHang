using QLBH.Models.DataRequest.Request_Models.Request_AddessReceive;
using QLBH.Models.DataResponse.Response_Models.DataRespon_AddessReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory.CMS.AddessReceive
{
    public interface IAddessReceive<TEntity,Bind> : IReponsitory<Request_AddessReceive,Respon_AddessReceive,long>
    {
    }
}
