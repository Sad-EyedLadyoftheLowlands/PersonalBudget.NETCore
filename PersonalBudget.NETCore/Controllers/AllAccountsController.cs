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

        [HttpGet("{id}")]
        public ObjectResult Index1(int id)
        {
            return new ObjectResult(allAccountsService.GetSpecificAccount(id));
        }
      
        [HttpPut("{id}")]
        public ObjectResult UpdateTransaction([FromBody] AllAccounts account)
        {
            return new ObjectResult(allAccountsService.UpdateTransaction(account));
        }

        [HttpPost]
        public ObjectResult CreateTransaction([FromBody] AllAccounts account)
        {
            return new ObjectResult(allAccountsService.CreateTransaction(account));
        }

        [HttpDelete("{id}")]
        public ObjectResult DeleteTransaction(int id)
        {
            return new ObjectResult(allAccountsService.DeleteTransaction(id));
        }
        
        
    }
}