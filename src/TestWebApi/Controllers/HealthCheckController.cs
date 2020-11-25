using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwareMD.DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [Route("api/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HealthCheckController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public string Index()
        {
            return "unit of work is fine";
        }
    }
}
