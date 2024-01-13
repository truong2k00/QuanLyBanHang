using Microsoft.AspNetCore.Http;
using QLBH.Commons;
using QLBH.Commons.Handle;
using QLBH.Models.DataRequest.Request_Models.Request_ImageProduct;
using QLBH.Models.DataResponse.Response_Models.DataRespon_ImageProduct;
using QLBH.Models.Entitis;
using QLBH.Responsives.Base;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Responsitory.CMS.ImageProducts
{
    public class ImageProductServices : IimageProducts<Respon_ImageProduct, long>
    {
        private readonly IBaseReponsitory<ImageProduct> _baseReponsitory;
        private readonly IHttpContextAccessor _httpContext;

        public ImageProductServices(IBaseReponsitory<ImageProduct> baseReponsitory, IHttpContextAccessor httpContext)
        {
            _baseReponsitory = baseReponsitory;
            _httpContext = httpContext;
        }

        public async Task<Respon_ImageProduct> Create(long ID, Request_ImageProduct item)
        {
            ImageProduct image = new ImageProduct
            {
                Image_Url = await HandleUploadImage.UploadImage(_httpContext.HttpContext.User.FindFirst("User").Value, item.file),
                Product_ID = ID
            };
            await _baseReponsitory.CreateAsync(image);
            return new Respon_ImageProduct
            {
                Image_Url = image.Image_Url
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _baseReponsitory.DeleteAsync(ID);
        }

        public async Task<IEnumerable<Respon_ImageProduct>> GetAllAsync(long IDProduct)
        {
            var lisimageproduct = await _baseReponsitory.GetAllAsync(x => x.Product_ID == IDProduct);
            var lisimage = lisimageproduct.Select(record => new Respon_ImageProduct
            {
                Image_Url = record.Image_Url
            });
            return lisimage;
        }

        public async Task<Respon_ImageProduct> GetByIDAsync(long ID)
        {
            var imagep = await _baseReponsitory.GetAsync(record => record.ID == ID);
            return new Respon_ImageProduct
            {
                Image_Url = imagep.Image_Url
            };
        }

        public async Task<Respon_ImageProduct> Update(long ID, Request_ImageProduct item)
        {
            var entityimage = await _baseReponsitory.GetByIDAsync(ID);
            var entity = new ImageProduct
            {
                Image_Url = await HandleUploadImage.UploadImage(
                    _httpContext.HttpContext.User.FindFirst(clames.USER).Value, item.file),
                Product_ID = entityimage.Product_ID
            };
            await _baseReponsitory.DeleteAsync(ID);
            await _baseReponsitory.CreateAsync(entity);
            return new Respon_ImageProduct
            {
                Image_Url = entityimage.Image_Url
            };
        }
    }
}
