using MySql.Data.MySqlClient;
using System;

namespace VeloMaxBDD
{
    class Connection
    {

        public static string connectionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=veloMax;" +
                                         "UID=bozo;PASSWORD=bozo";
        public static void update (string mySQLCommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLCommand;
            
            try
            {
                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            connection.Close();
            command.Dispose();
        }
        public static void select (string mySQLcommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLcommand;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string valueAsString = reader.GetValue(i).ToString();
                    currentRowAsString += valueAsString + "| ";
                }
                Console.WriteLine(currentRowAsString);
            }
            reader.Close();
            command.Dispose();
            connection.Close();

        }
        public static string selectUnique(string mySQLcommand)
        {
            MySqlConnection connection = new MySqlConnection(Connection.connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = mySQLcommand;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string rep = "";
            while (reader.Read())
            {
                rep = reader.GetValue(0).ToString();
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return rep;
        }
    }
}
