using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IRepository repository, IConfiguration configuration, ILogger<AdminController> logger)
        {
            _configuration = configuration;
            _repository = repository;
            _logger = logger;
            _logger.LogInformation("\n\n AdminController Logs : \n");
        }

    }
}
