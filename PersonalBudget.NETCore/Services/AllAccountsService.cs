using System.Collections.Generic;
using PersonalBudget.NETCore.Models;
using Npgsql;
using System;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBudget.NETCore.Services
{
    public interface IAllAccountsService
    {
        List<AllAccounts> GetAllAccounts();
        AllAccounts GetSpecificAccount(int id);
        bool UpdateTransaction(AllAccounts account);
        bool CreateTransaction(AllAccounts account);
    }
    
    public class AllAccountsService : IAllAccountsService
    {
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
                        // "SELECT * FROM allaccountstransactions";
                        "SELECT id, date, payee, category, memo, expense, income, balance FROM allaccountstransactions";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var allAccount = new AllAccounts();
                            allAccount.id = reader.GetInt32(0);
                            allAccount.date = reader.GetDateTime(1);
                            allAccount.payee = reader.GetString(2);
                            allAccount.category = reader.GetString(3);
                            allAccount.memo = reader.GetString(4);
                            allAccount.expense = reader.GetInt32(5);
                            allAccount.income = reader.GetInt32(6);
                            allAccount.balance = reader.GetInt32(7);
                            allAccounts.Add(allAccount);
                        }
                    }

                    transaction.Commit();
                }
            
            return allAccounts;
        }

        public AllAccounts GetSpecificAccount(int id)
        {
            AllAccounts account = new AllAccounts();
            
            var cs = "Host=167.114.144.182;Username=dbaird;Password=N3!lY0ng;Database=dylan";
            using var connection = new NpgsqlConnection(cs);
            
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = 
                        "SELECT * FROM allaccountstransactions WHERE id = @id"; // @id will probably work, $id is a syntax error
                    selectCommand.Parameters.AddWithValue("@id", id); // if it's @id above, should it be here as well? I can't test it though because Angular is sending 5
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            account.id = reader.GetInt32(0);
                            account.date = reader.GetDateTime(1);
                            account.payee = reader.GetString(2);
                            account.category = reader.GetString(3);
                            account.memo = reader.GetString(4);
                            account.expense = reader.GetInt32(5);
                            account.income = reader.GetInt32(6);
                            account.balance = reader.GetInt32(7);
                        }
                    }
                    transaction.Commit();
                }
                return account;
        }

        

        public bool UpdateTransaction(AllAccounts account)
        {
            var cs = "Host=167.114.144.182;Username=dbaird;Password=N3!lY0ng;Database=dylan";
            using var connection = new NpgsqlConnection(cs);
            
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCommand = connection.CreateCommand();
                    updateCommand.Transaction = transaction;
                    updateCommand.CommandText = // everything below is changed, like above to replace $ with @ ??? is this better?
                        "UPDATE allaccountstransactions SET date = @date, payee = @payee, category = @category, memo = @memo, expense = @expense, income = @income, balance = @balance WHERE id = @id";
                    updateCommand.Parameters.AddWithValue("@date", account.date);
                    updateCommand.Parameters.AddWithValue("@payee", account.payee);
                    updateCommand.Parameters.AddWithValue("@category", account.category);
                    updateCommand.Parameters.AddWithValue("@memo", account.memo);
                    updateCommand.Parameters.AddWithValue("@expense", account.expense);
                    updateCommand.Parameters.AddWithValue("@income", account.income);
                    updateCommand.Parameters.AddWithValue("@balance", account.balance);
                    updateCommand.Parameters.AddWithValue("@id", account.id);
                    updateCommand.ExecuteNonQuery();
                                                    
                    transaction.Commit();
                }
                return true;
        }

        public bool CreateTransaction(AllAccounts account)
        {
            var cs = "Host=167.114.144.182;Username=dbaird;Password=N3!lY0ng;Database=dylan";
            using var connection = new NpgsqlConnection(cs);
            
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                var updateCommand = connection.CreateCommand();
                updateCommand.Transaction = transaction;
                updateCommand.CommandText = // everything below is changed, like above to replace $ with @ ??? is this better?
                    "INSERT INTO allaccountstransactions VALUES (date, payee, category, memo, expense, income, balance, id)";
                updateCommand.Parameters.AddWithValue("@date", account.date);
                updateCommand.Parameters.AddWithValue("@payee", account.payee);
                updateCommand.Parameters.AddWithValue("@category", account.category);
                updateCommand.Parameters.AddWithValue("@memo", account.memo);
                updateCommand.Parameters.AddWithValue("@expense", account.expense);
                updateCommand.Parameters.AddWithValue("@income", account.income);
                updateCommand.Parameters.AddWithValue("@balance", account.balance);
                updateCommand.Parameters.AddWithValue("@id", account.id);
                updateCommand.ExecuteNonQuery();
                                                    
                transaction.Commit();
            }
            return true;
        }
    }
}