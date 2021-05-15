using MySql.Data.MySqlClient;
using System;

namespace VeloMaxBDD
{
    class Connection
    {

        public static string connectionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=veloMax;" +
                                         "UID=root;PASSWORD=Valou1234";
        public static void update (string mySQLCommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLCommand;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
        }
        public static void select (string mySQLcommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLcommand;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            command.Dispose();
            connection.Close();

        }
    }
}
