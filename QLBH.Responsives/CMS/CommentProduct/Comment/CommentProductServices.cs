using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using QLBH.Commons;
using QLBH.Models.DataRequest.Request_Models.Request_Comment;
using QLBH.Models.DataResponse.Response_Models;
using QLBH.Models.Entitis;
using QLBH.Responsives.Base;
using QLPT2.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Responsitory.CMS.CommentProduct.Comment
{
    public class CommentProductServices : ICommentProduct<DataRequest_CommentProduct>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBaseReponsitory<Account> _reponsitoryAccount;
        private readonly IBaseReponsitory<Comment_Product> _reponsitoryComment;
        private readonly IBaseReponsitory<Product> _reponsitoryProduct;
        private readonly ResponcesObject<DataRespon_CommentProduct> _dataRespon;

        public CommentProductServices(IHttpContextAccessor httpContext
            , IBaseReponsitory<Account> reponsitoryAccount
            , IBaseReponsitory<Comment_Product> reponsitoryComment
            , IBaseReponsitory<Product> reponsitoryProduct)
        {
            _httpContext = httpContext;
            _reponsitoryAccount = reponsitoryAccount;
            _reponsitoryComment = reponsitoryComment;
            _reponsitoryProduct = reponsitoryProduct;
        }

        public async Task<ResponcesObject<DataRespon_CommentProduct>> CreateAsync(
            DataRequest_CommentProduct entity)
        {
            var product = await _reponsitoryProduct.GetAsync(record => record.Meta_Product == entity.Meta_Product);
            var listComment = new List<Comment_Product>();
            var comment = new Comment_Product
            {
                Datetime_Comment = DateTime.Now,
                Document = entity.Document,
                Account = await _reponsitoryAccount.GetAsync(record => record.ID == long.Parse(_httpContext.HttpContext.User.FindFirst(clames.ID).Value))
            };
            listComment.Add(comment);
            product.Comment_Product = listComment;
            await _reponsitoryProduct.UpdateAsync(product);
            return _dataRespon.ResponcesSuccess(Common_Constants.SUCCESS, new DataRespon_CommentProduct
            {
                User = comment.Account.User_Name, 
                Comment = comment.Document,
                Date_create = comment.Datetime_Comment,
            });
        }
    }
}
