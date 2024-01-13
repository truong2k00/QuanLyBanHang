using Microsoft.Identity.Client;
using QLBH.Models.DataResponse.Response_Models.DataResponse_product;
using QLBH.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Converter.Convert_product
{
    public class Converter_Product
    {
        private readonly AppDbContext _appDbContext;

        public Converter_Product(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public DataResponse_Product EntituDTO(Product product)
        {
            DataResponse_Product Data = new DataResponse_Product
            {
                Product_ID = product.ID,
                Product_Name = product.Product_Name,
                Product_Description = product.Product_Description,
                Meta_Product = product.Meta_Product,
                Catogory_ID = product.Catogory_ID,
                Is_New = product.Is_New,
                Sale = product.Sale,
                Quantity = product.Quantity,
                Price = product.Price,
                Price_Sale = product.Price_Sale,
                Account_ID = product.Acount_ID,
                Evaluate = product.Evaluate,
                ImageProduct = product.ImageProduct
            };
            return Data;
        }
    }
}
