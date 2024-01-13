using QLBH.Models.DataResponse.Response_Models;
using QLPT2.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory.CMS.CommentProduct.Comment
{
    public interface ICommentProduct<TEntity> where TEntity : class
    {
        Task<ResponcesObject<DataRespon_CommentProduct>> CreateAsync(TEntity entity);
    }
}
