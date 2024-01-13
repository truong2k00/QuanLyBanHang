using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Models.DataRequest.Request_Models.Request_AddessReceive;
using QLBH.Models.DataResponse.Response_Models.DataRespon_AddessReceive;
using QLBH.Responsitory.CMS.AddessReceive;

namespace QLBH.Api.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddessReceiveController : ControllerBase
    {
        private readonly IAddessReceive<Respon_AddessReceive,long> _addessReceive;

        public AddessReceiveController(IAddessReceive<Respon_AddessReceive, long> addessReceive)
        {
            _addessReceive = addessReceive;
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Request_AddessReceive request_AddessReceive)
        {
            return Ok(await _addessReceive.Create(1,request_AddessReceive));
        }
    }
}
