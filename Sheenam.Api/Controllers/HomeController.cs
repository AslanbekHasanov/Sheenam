//=================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//=================================

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Sheenam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController: RESTFulController
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello Net");

    }
}
