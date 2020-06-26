using System;

namespace PersonalBudget.NETCore.Models
{
    public class TestModel
    {
        public DateTime date { get; set; }
        public string payee { get; set; }
        public string category { get; set; }
        public string memo { get; set; }
        public int expense { get; set;}
        public int income { get; set; }
        public int balance { get; set; }
    }
}