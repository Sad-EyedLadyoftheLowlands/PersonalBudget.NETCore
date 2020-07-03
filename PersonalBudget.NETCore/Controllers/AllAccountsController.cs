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
        public ObjectResult Index1(Int64 id)
        {
            return new ObjectResult(allAccountsService.GetSpecificAccount(id));
        }
        // This might be better off as a PUT request, and so I will simply copy this and test it that way...
        /*
        [HttpPatch("{id}")]
        public ObjectResult UpdateTransaction([FromBody] AllAccounts account)
        {
            return new ObjectResult(allAccountsService.UpdateTransaction(account));
        }
        */
        // TESTING AS A PUT REQUEST
        [HttpPut("{id}")]
        public ObjectResult UpdateTransaction([FromBody] AllAccounts account)
        {
            return new ObjectResult(allAccountsService.UpdateTransaction(account));
        }
/*
        [HttpPost]
        public ObjectResult CreateTransaction([FromBody] AllAccounts transaction)
        {
            return new ObjectResult(allAccountsService.CreateTransaction(transaction));
        }
        */
    }
}