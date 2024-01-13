using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using QLBH.Commons;
using QLBH.Commons.Common_Page;
using QLBH.Models.DataRequest;
using QLBH.Models.DataRequest.Request_Models.Request_product;
using QLBH.Models.DataResponse.Response_Models.DataResponse_product;
using QLBH.Models.Entitis;
using QLBH.Responsitory.CMS.product;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using rolex = QLBH.Commons.Common_Constants.RoleKeyString;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using static Microsoft.VisualStudio.Services.Notifications.VssNotificationEvent;

namespace QLBH.Api.Controllers.CMS
{
    [Route(Common_Constants.AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices<DataResponse_Product, int> _productServices;
        public ProductController(IProductServices<DataResponse_Product, int> productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] Request_Product product,[FromForm] RequestFiles files)
        {
            var CreateAsync = await _productServices.Create(product,files);
            return Ok(CreateAsync);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] int ID, [FromBody] Request_Product product)
        {
            return Ok(await _productServices.Update(ID, product));
        }
        [HttpGet("GetAll-Product")]
        public async Task<IActionResult> GetAll([FromQuery] Request_Pagination pagination, [FromQuery] string KeyWord)
        {
            return Ok(await _productServices.GetAll(new Pagination
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber
            }, KeyWord));
        }
    }
}
