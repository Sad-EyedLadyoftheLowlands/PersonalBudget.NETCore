using System;
using PersonalBudget.NETCore.Models;

namespace PersonalBudget.NETCore.Services
{
    public interface ITestService
    {
        TestModel allAccountsTableTest();
    }
    public class TestService : ITestService
    {
        public TestModel allAccountsTableTest()
        {
            TestModel test = new TestModel
            {
                date = DateTime.Today,
                payee = "",
                category = "Monthly Expenses",
                memo = "Some comment about the expense...",
                expense = 200,
                income = 0,
                balance = 1000
            };
            return test;
        }
    }
}