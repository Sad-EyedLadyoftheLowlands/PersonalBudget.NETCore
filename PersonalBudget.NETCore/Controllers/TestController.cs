using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PersonalBudget.NETCore.Services;

namespace PersonalBudget.NETCore.Controllers
{
    // DECORATORS 
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GLOBAL VARIABLES?
        private readonly ILogger<TestController> logger;
        private readonly ITestService testService;
        
        // CONSTRUCTOR
        public TestController(ILogger<TestController> _logger, ITestService _testService)
        {
            logger = _logger;
            testService = _testService;
        }
        
        // HTTP GET REQUESTS
        [HttpGet]
        public ObjectResult Index()
        {
            return new ObjectResult(new Label{label = "default"});
        }
        
        [HttpGet("allAccountsTableTest")]
        public ObjectResult TestObject()
        {
            return new ObjectResult(testService.allAccountsTableTest());
        }
    }
    // PREVENTING SCALARS IN JSON
    public class Label
    {
        public string label { get; set; }
    }
}