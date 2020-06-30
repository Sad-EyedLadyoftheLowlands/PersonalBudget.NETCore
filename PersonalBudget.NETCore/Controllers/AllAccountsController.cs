using System;
using PersonalBudget.NETCore.Models;
using PersonalBudget.NETCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonalBudget.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllAccountsController
    {
        private readonly ILogger<AllAccountsController> logger;
        private readonly IAllAccountsService allAccountsService;
        
        // CONSTRUCTOR
        public AllAccountsController(ILogger<AllAccountsController> _logger, IAllAccountsService _allAccountsService)
        {
            logger = _logger;
            allAccountsService = _allAccountsService;
        }
        
        // HTTP REQUESTS
        [HttpGet]
        public ObjectResult Index()
        {
            return new ObjectResult(allAccountsService.GetAllAccounts());
        }
    }
}