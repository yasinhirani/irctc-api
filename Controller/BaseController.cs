using irctc.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace irctc.Controller
{
    [ApiController]
    [Route("/")]
    public class BaseController : ControllerBase
    {
        public BaseController() { }
        [HttpGet]
        public IActionResult GetBase()
        {
            return Ok(new ResponseDto<string> { Data = "Welcome to Unofficial IRCTC Api", Error = "" });
        }
    }
}