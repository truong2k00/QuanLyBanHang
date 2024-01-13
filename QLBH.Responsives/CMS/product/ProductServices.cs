using QLBH.Models.Entitis;
using QLBH.Models;
using QLBH.Responsives.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Diagnostics;
using QLBH.Models.DataRequest.Request_Models.Request_product;
using QLBH.Models.Converter.Convert_product;
using QLBH.Models.DataResponse.Response_Models.DataResponse_product;
using System.Security.Principal;
using QLPT2.Commons.Responces;
using QLBH.Commons.Common_Page;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using QLBH.Commons;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using QLBH.Commons.Handle;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
using QLBH.Models.DataRequest;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Responsitory.CMS.product
{
    public class ProductServices : IProductServices<DataResponse_Product, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly Converter_Product _converter;
        private readonly IBaseReponsitory<Product> _baseReponsitory;
        private readonly IBaseReponsitory<Account> _baseAccountReponsitory;
        private readonly IBaseReponsitory<ProductCatogory> _baseCatogoryReponsitory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductServices(IBaseReponsitory<Account> baseAccountReponsitory
            , IHttpContextAccessor httpContextAccessor
            , Converter_Product converter
            , AppDbContext appDbContext
            , IBaseReponsitory<Product> baseReponsitory
            , IBaseReponsitory<ProductCatogory> baseCatogoryReponsitory)
        {
            _baseCatogoryReponsitory = baseCatogoryReponsitory;
            _baseAccountReponsitory = baseAccountReponsitory;
            _httpContextAccessor = httpContextAccessor;
            _baseReponsitory = baseReponsitory;
            _converter = converter;
            _appDbContext = appDbContext;
        }
        public async Task<DataResponse_Product> Create(Request_Product item, RequestFiles files)
        {
            var account = await _baseAccountReponsitory.GetAsync(record => record.ID ==
                long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(clames.ID).Value));
            var product = new List<Product>();
            Product entity = new Product
            {
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Meta_Product = MetaProducts(),
                Catogory_ID = item.Catogory_ID,
                ProductCatogory = await _baseCatogoryReponsitory.GetAsync(x => x.ID == item.Catogory_ID),
                Is_New = item.Is_New,
                Sale = item.Sale,
                Date_Delete = null,
                Is_Deleted = false,
                Quantity = item.Quantity,
                Price = item.Price,
                Price_Sale = item.Price_Sale,
                Evaluate = 5,
                Deleted = false,
                ImageProduct = await GenerateImageProduct(files.Files)
            };
            product.Add(entity);
            account.Product = product;
            await _baseAccountReponsitory.UpdateAsync(account);
            return new DataResponse_Product
            {
                Meta_Product = entity.Meta_Product,
                Product_ID = entity.ID,
                Account_ID = account.ID,
                Catogory_ID = entity.Catogory_ID,
                Product_Name = entity.Product_Name,
                Product_Description = entity.Product_Description,
                Is_New = entity.Is_New,
                Quantity = entity.Quantity,
                Price = entity.Price,
                Price_Sale = entity.Price_Sale,
                Evaluate = 5
            };
        }
        public async Task<List<ImageProduct>> GenerateImageProduct(List<IFormFile> Files)
        {
            if (Files != null)
            {
                var productImages = new List<ImageProduct>();
                foreach (var file in Files)
                {
                    productImages.Add(new ImageProduct
                    {
                        Image_Url = await HandleUploadImage.UploadImage(_httpContextAccessor.HttpContext.User.FindFirst(clames.USER).Value, file)
                    });
                }
                return productImages;
            }
            return null;
        }
        public async Task<bool> Delete(int ID)
        {
            var product = await _appDbContext.Product.FirstOrDefaultAsync(x => x.ID == ID);
            product.Deleted = true;
            await _baseReponsitory.UpdateAsync(product);
            return true;
        }

        public async Task<string> Get()
        {
            var x = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return x;
        }
        public async Task<DataResponse_Product> Update(int ID, Request_Product item)
        {
            var productEntity = _appDbContext.Product.FirstOrDefault(x => x.ID == ID);
            if (productEntity != null)
            {
                return null;
            }
            else return _converter.EntituDTO(await _baseReponsitory.UpdateAsync(productEntity));
        }

        public async Task<DataResponse_Product> GetByID(int ID)
        {
            return _converter.EntituDTO(await _baseReponsitory.GetByIDAsync(ID));
        }

        public async Task<PageResult<DataResponse_Product>> GetAll(Pagination pagination, string KeyWord)
        {
            IEnumerable<Product> entitis = KeyWord != null ?
                await _baseReponsitory.GetAllAsync(x => x.Product_Name.ToLower().Contains(KeyWord.ToLower()) ||
                                                        x.Price.ToString().Contains(KeyWord.ToLower()) ||
                                                        x.ProductCatogory.ID.ToString() == KeyWord)
                : await _baseReponsitory.GetAllAsync();

            var Data = entitis.Select(x => _converter.EntituDTO(x));

            pagination.TotalCount = Data.Count();
            var result = PageResult<DataResponse_Product>.ToPageResult(pagination, Data);
            return new PageResult<DataResponse_Product>(pagination, result);
        }

        public Task<DataResponse_Product> Create(int ID, Request_Product item)
        {
            throw new NotImplementedException();
        }
        public string MetaProducts()
        {
            var longrand = randomlong();
            while (_appDbContext.Product.Any(x => x.Meta_Product == longrand))
            {
                longrand = randomlong();
            }
            return longrand;
        }
        public string randomlong()
        {
            byte[] buf = new byte[8];
            Random rand = new Random();
            rand.NextBytes(buf);
            long longrand = BitConverter.ToInt64(buf, 0);
            return "SP" + longrand;
        }
    }
}
