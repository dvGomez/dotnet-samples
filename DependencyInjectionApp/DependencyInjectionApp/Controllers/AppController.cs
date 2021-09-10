using Domain.App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IAppService objAppService;

        public AppController(IAppService objAppService)
        {
            this.objAppService = objAppService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.objAppService.HelloWorld());
        }
    }
}
