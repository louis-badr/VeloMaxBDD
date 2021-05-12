using MySql.Data.MySqlClient;
using System;

namespace VeloMaxBDD
{
    class Connection
    {

        public static string connectionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=veloMax;" +
                                         "UID=root;PASSWORD=Valou1234";
        public static void SQLcomm (string mySQLCommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLCommand;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            
        }
    }
}
