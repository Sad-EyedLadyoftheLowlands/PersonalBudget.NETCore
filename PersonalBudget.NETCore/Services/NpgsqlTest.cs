using System;
using System.Reflection.Metadata;
using Npgsql;

namespace PersonalBudget.NETCore.Services
{
    public class NpgsqlTest
    {
        // DATABSE CONNECTION SETTINGS
        private const String Server = "192.168.2.46";
        private const String Port = "5432";
        private const String User = "dbaird";
        private const String Password = "N3!lY0ng";
        private const String Database = "dylan";

        private NpgsqlConnection connection = null;
        
        // CONSTRUCTOR
        public NpgsqlTest()
        {
            // CREATE CONNECTION OBJECT
            connection = new NpgsqlConnection(
                "Server=" + Server + ";" +
                "Port=" + Port + ";" +
                "User Id=" + User + ";" +
                "Password=" + Password + ";" +
                "Database=" + Database + ";");
        }
        
        // OPEN CONNECTION
        private void openConnection()
        {
            connection.Open();
        }
        
        // CLOSE CONNECTION
        private void closeConnection()
        {
            connection.Close();
        }
    }
}