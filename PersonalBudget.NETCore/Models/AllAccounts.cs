using System;

namespace PersonalBudget.NETCore.Models
{
    public class AllAccounts
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string payee { get; set; }
        public string category { get; set; }
        public string memo { get; set; }
        public Int32 expense { get; set;}
        public Int32 income { get; set; }
        public Int32 balance { get; set; }

        public AllAccounts() { }
    }
}