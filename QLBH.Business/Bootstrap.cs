using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QLBH.Commons.Common_Page;
using QLBH.Models;
using QLBH.Models.Converter.Convert_product;
using QLBH.Models.DataRequest.Request_Models.Request_product;
using QLBH.Models.DataResponse.Response_Models;
using QLBH.Models.DataResponse.Response_Models.DataRespon_AddessReceive;
using QLBH.Models.DataResponse.Response_Models.DataResponse_product;
using QLBH.Models.Entitis;
using QLBH.Responsitory;
using QLBH.Responsitory.Auth;
using QLBH.Responsitory.CMS.AddessReceive;
using QLBH.Responsitory.CMS.product;
using QLBH.Responsives.Base;
using QLPT2.Business;
using QLPT2.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public static class Bootstrap
    {
        public static void DependencyServices(this IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<IAuthServices, AuthServices>();
            services.AddSingleton<ResponcesObject<Account>>();
            services.AddScoped<ResponcesObject<DataResponseToken>>();


            services.AddScoped<IProductServices<DataResponse_Product, int>, ProductServices>();
            services.AddScoped<IReponsitory<Request_Product, DataResponse_Product, int>, ProductServices>();

            services.AddScoped<IAddessReceive<Respon_AddessReceive, long>, AddessReceiveServices>();

            RegisterRepositoryDependencies(services);
            RegisterConvertDependencies(services);
            ResponcesObjectDependencies(services);
        }
        private static void RegisterConvertDependencies(IServiceCollection services)
        {
            services.AddScoped<Converter_Product>();
        }
        private static void RegisterRepositoryDependencies(IServiceCollection services)
        {
            services.AddScoped<IBaseReponsitory<Account>>(service => new BaseReponsitory<Account>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Addess_Receive>>(service => new BaseReponsitory<Addess_Receive>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Bill>>(service => new BaseReponsitory<Bill>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Cart>>(service => new BaseReponsitory<Cart>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<ConfirmEmail>>(service => new BaseReponsitory<ConfirmEmail>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Decentralization>>(service => new BaseReponsitory<Decentralization>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Details>>(service => new BaseReponsitory<Details>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Detail_Cart>>(service => new BaseReponsitory<Detail_Cart>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<FeedBack>>(service => new BaseReponsitory<FeedBack>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<ImageProduct>>(service => new BaseReponsitory<ImageProduct>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Invoice_Details>>(service => new BaseReponsitory<Invoice_Details>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<MailSetting>>(service => new BaseReponsitory<MailSetting>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Notification>>(service => new BaseReponsitory<Notification>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Product>>(service => new BaseReponsitory<Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<ProductCatogory>>(service => new BaseReponsitory<ProductCatogory>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<RefeshToken>>(service => new BaseReponsitory<RefeshToken>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Role>>(service => new BaseReponsitory<Role>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Status_Bill>>(service => new BaseReponsitory<Status_Bill>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Type_Product>>(service => new BaseReponsitory<Type_Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Voucher>>(service => new BaseReponsitory<Voucher>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Comment_Product>>(service => new BaseReponsitory<Comment_Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseReponsitory<Image_Comment>>(service => new BaseReponsitory<Image_Comment>(service.GetService<IAppDbContext>()));
        }
        private static void ResponcesObjectDependencies(IServiceCollection services)
        {
            services.AddScoped<ResponcesObject<DataResponse_Product>>();
            services.AddScoped<ResponcesObject<DataRespon_CommentProduct>>();
        }
    }
}
