using System.Collections.Generic;
using PersonalBudget.NETCore.Models;
using Npgsql;
using System;

namespace PersonalBudget.NETCore.Services
{
    public interface IAllAccountsService
    {
        List<AllAccounts> GetAllAccounts();
    }
    
    public class AllAccountsService : IAllAccountsService
    {
        // TODO: JM OPENS CURLY BRACKETS BEFORE OPENING CONNECTION... SHOULD I?
        public List<AllAccounts> GetAllAccounts()
        {
            List<AllAccounts> allAccounts = new List<AllAccounts>();
            
            var cs = "Host=167.114.144.182;Username=dbaird;Password=N3!lY0ng;Database=dylan";

            using var connection = new NpgsqlConnection(cs);
            
               
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText =
                        "SELECT date, payee, category, memo, expense, income, balance FROM allaccounts";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var allAccount = new AllAccounts();
                            allAccount.date = reader.GetDateTime(0);
                            allAccount.payee = reader.GetString(1);
                            allAccount.category = reader.GetString(2);
                            allAccount.memo = reader.GetString(3);
                            allAccount.expense = reader.GetInt32(4);
                            allAccount.income = reader.GetInt32(5);
                            allAccount.balance = reader.GetInt32(6);
                            allAccounts.Add(allAccount);
                        }
                    }

                    transaction.Commit();
                }
            
            return allAccounts;
        }
        
    }
}