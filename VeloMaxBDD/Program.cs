using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeloMaxBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=veloMax;" +
                                         "UID=root;PASSWORD=Valou1234";

                connexion = new MySqlConnection(connexionString);
                connexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            Choix_interface();
            //exo(connexion);
            connexion.Close();
            Console.ReadKey();
        }

        static void Choix_interface()
        {
            Console.WriteLine("Que souhaitez vous faire ?");
            Console.WriteLine("1. Gestion des pièces\n2. Gestion des vélos \n3. Gestion des clients particuliers \n4. Gestion des clients boutique \n5. Gestion des fournisseurs \n6. Gestion des commandes");
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'une pièce \n2. Suppression d'une pièce \n3. MAJ d'une pièce");
                    int caseSwitch2 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch2)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'un modèle \n2. Suppression d'un modele \n3. MAJ d'un modèle");
                    int caseSwitch3 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch3)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'un client particulier avec programme Fidelio \n2. Création d'un client particulier sans programme Fidelio \n3. Suppression d'un client particulier \n4. MAJ d'un client particulier");
                    int caseSwitch4 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch4)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                        case 4:
                            Console.WriteLine("no");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'un client boutique avec remise \n2. Création d'un client boutique sans remise \n3. Suppression d'un client boutique \n4. MAJ d'un client boutique");
                    int caseSwitch5 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch5)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                        case 4:
                            Console.WriteLine("no");
                            break;
                    }
                    break;
                case 5:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'un fournisseur \n2. Suppression d'un fournisseur \n3. MAJ d'un fournisseur");
                    int caseSwitch6 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch6)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                      
                    }
                    break;
                case 6:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'une commande \n2. Suppression d'une commande \n4. MAJ d'une commande");
                    int caseSwitch7 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch7)
                    {
                        case 1:
                            Console.WriteLine("yes");
                            break;
                        case 2:
                            Console.WriteLine("ok");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                        case 4:
                            Console.WriteLine("no");
                            break;
                    }
                    break;
                    
            }
            

        }
        static void exo(MySqlConnection connexion)
        {
            Console.WriteLine("Saissez une piece");
            string no_piece = Convert.ToString(Console.ReadLine());
            string requete = $"Select stock from Piece where no_piece = \"{no_piece}\";";
            MySqlCommand command1 = connexion.CreateCommand();
            command1.CommandText = requete;
            int stock = 0;
            MySqlDataReader reader = command1.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                stock = Convert.ToInt32(reader["stock"]);
                Console.WriteLine(stock);
            }
            if (stock == 0)
            {
                Console.WriteLine("La pièce n'existe pas");
            }

        }
    }
}
