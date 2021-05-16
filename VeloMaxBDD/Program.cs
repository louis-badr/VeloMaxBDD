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
                                         "UID=root;PASSWORD=root";

                connexion = new MySqlConnection(connexionString);
                connexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }





            // lecture de la table fournisseur
            List<Fournisseur> listeFournisseurs = new List<Fournisseur>();
            string requete = "Select * from fournisseur;";
            MySqlCommand command1 = connexion.CreateCommand();
            command1.CommandText = requete;
            MySqlDataReader reader = command1.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount/5; i=i+5)
                {
                    listeFournisseurs.Add(new Fournisseur(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i+2).ToString(), reader.GetValue(i+3).ToString(), Convert.ToInt32(reader.GetValue(i+4).ToString())));
                }
            }
            reader.Close();
            command1.Dispose();

            //foreach(Fournisseur fournisseur in listeFournisseurs)
            //{
            //    Console.WriteLine(fournisseur.Siret_fournisseur+ " | " + fournisseur.Nom_fournisseur+ " | " + fournisseur.Contact_fournisseur+ " | " + fournisseur.Adresse_fournisseur+ " | " + fournisseur.Note_fournisseur);
            //}

            // lecture de la table pièce
            List<Piece> listePieces = new List<Piece>();
            requete = "Select * from piece;";
            MySqlCommand command2 = connexion.CreateCommand();
            command2.CommandText = requete;
            reader = command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 5; i = i + 5)
                {
                    listePieces.Add(new Piece(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), reader.GetValue(i + 3).ToString(), Convert.ToInt32(reader.GetValue(i + 4).ToString())));
                }
            }
            reader.Close();
            command2.Dispose();

            //foreach (Piece piece in listePieces)
            //{
            //    Console.WriteLine(piece.No_piece + " | " + piece.Desc_piece + " | " + piece.Date_intro_piece + " | " + piece.Date_disco_piece + " | " + piece.Stock);
            //}

            // lecture de la table boutique
            List<Boutique> listeBoutiques = new List<Boutique>();
            requete = "Select * from boutique;";
            MySqlCommand command3 = connexion.CreateCommand();
            command3.CommandText = requete;
            reader = command3.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 7; i = i + 7)
                {
                    listeBoutiques.Add(new Boutique(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), reader.GetValue(i + 3).ToString(), reader.GetValue(i + 4).ToString(), reader.GetValue(i + 5).ToString(), Convert.ToInt32(reader.GetValue(i + 6).ToString())));
                }
            }
            reader.Close();
            command3.Dispose();

            //foreach (Boutique boutique in listeBoutiques)
            //{
            //    Console.WriteLine(boutique.No_boutique + " | " + boutique.Nom_boutique + " | " + boutique.Adresse_boutique + " | " + boutique.Tel_boutique + " | " + boutique.Mail_boutique + " | " + boutique.Contact_boutique + " | " + boutique.Remise_boutique);
            //}

            // lecture de la table commande
            List<Commande> listeCommandes = new List<Commande>();
            requete = "Select * from commande;";
            MySqlCommand command4 = connexion.CreateCommand();
            command4.CommandText = requete;
            reader = command4.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 4; i = i + 4)
                {
                    listeCommandes.Add(new Commande(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), reader.GetValue(i + 3).ToString()));
                }
            }
            reader.Close();
            command4.Dispose();

            //foreach (Commande commande in listeCommandes)
            //{
            //    Console.WriteLine(commande.No_commande + " | " + commande.Date_commande + " | " + commande.Adresse_livraison + " | " + commande.Date_livraison);
            //}

            // lecture de la table modele
            List<Modele> listeModeles = new List<Modele>();
            requete = "Select * from modele;";
            MySqlCommand command5 = connexion.CreateCommand();
            command5.CommandText = requete;
            reader = command5.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 7; i = i + 7)
                {
                    listeModeles.Add(new Modele(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), Convert.ToInt32(reader.GetValue(i + 3).ToString()), reader.GetValue(i + 4).ToString(), reader.GetValue(i + 5).ToString(), reader.GetValue(i + 6).ToString()));
                }
            }
            reader.Close();
            command5.Dispose();

            //foreach (Modele modele in listeModeles)
            //{
            //    Console.WriteLine(modele.No_modele + " | " + modele.Nom_modele + " | " + modele.Grandeur + " | " + modele.Prix_modele + " | " + modele.Ligne + " | " + modele.Date_intro_modele + " | " + modele.Date_disco_modele);
            //}

            // lecture de la table particulier
            List<Particulier> listeParticuliers = new List<Particulier>();
            requete = "Select * from particulier;";
            MySqlCommand command6 = connexion.CreateCommand();
            command6.CommandText = requete;
            reader = command6.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 7; i = i + 7)
                {
                    listeParticuliers.Add(new Particulier(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), reader.GetValue(i + 3).ToString(), reader.GetValue(i + 4).ToString(), reader.GetValue(i + 5).ToString(), reader.GetValue(i + 6).ToString(), Convert.ToInt32(reader.GetValue(i + 7).ToString())));
                }
            }
            reader.Close();
            command6.Dispose();

            //foreach (Particulier particulier in listeParticuliers)
            //{
            //    Console.WriteLine(particulier.No_particulier + " | " + particulier.Nom_particulier + " | " + particulier.Prenom_particulier + " | " + particulier.Adresse_particulier + " | " + particulier.Tel_particulier + " | " + particulier.Mail_particulier + " | " + particulier.Date_souscription + " | " + particulier.No_programme);
            //}

            Console.WriteLine(listeParticuliers[0].ToString());
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
                            Console.WriteLine("Saisissez un numero de pièce");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une description");
                            string desc = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date d'introduction (JJ/MM/AAAA)");
                            string dateintro = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de discontinuation (JJ/MM/AAAA)");
                            string datedisco = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un stock");
                            int stock = Convert.ToInt32(Console.ReadLine());
                            Piece p1 = new Piece(No, desc, dateintro, datedisco, stock);
                            p1.CreatePiece();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez le N° de pièce à supprimer" );
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Piece where no_piece=" + numsupp + ";");
                            Console.WriteLine("Pièce supprimée");
                            break;
                        case 3:
                            Console.WriteLine("Voici toutes les pièces :");
                            Connection.select("select * from Piece");
                            Console.WriteLine();
                            Console.WriteLine("Quelle pièce voulez vous modifier ?");

                            Console.WriteLine("Que voulez vous modifier ?");
                            Console.WriteLine("1. N° Piece \n2. Description \n3. Date introduction \n4. Date introduction \n5. Date discontinuation \n6. Stock" );
                            int numupdate = Convert.ToInt32(Console.ReadLine());
                            if (numupdate == 1)
                            {

                            }
                            Connection.update("delete from Piece where no_piece=" + numupdate + ";");
                            Console.WriteLine("Pièce supprimée");
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
                            Console.WriteLine("Saisissez un numero de modèle (3 chiffres)");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom de modèle");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une grandeur");
                            string grandeur = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un prix");
                            int prix = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Saisissez une ligne");
                            string ligne = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date d'introduction (JJ/MM/AAAA)");
                            string date_intro = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de discontinuiation (JJ/MM/AAAA)");
                            string date_disco = Convert.ToString(Console.ReadLine());
                            Modele m1 = new Modele(No, nom, grandeur, prix, ligne,date_intro,date_disco);
                            m1.CreateModele();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez le N° du modele à supprimer (3 chiffres)");
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Modele where no_modele=" + numsupp + ";");
                            Console.WriteLine("Modèle supprimé");
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
                            Console.WriteLine("Saisissez un numero de client particulier (2 chiffres)");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom ");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un prenom");
                            string prenom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse (numéro,rue,ville)");
                            string adresse = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un telephone");
                            string tel = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un mail");
                            string date_intro = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de souscription (JJ/MM/AAAA)");
                            string date_souscription = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saissez un numéro de programme Fidélio");
                            int prog = Convert.ToInt32(Console.ReadLine());
                            Particulier part1 = new Particulier(No, nom, prenom, adresse, tel, date_intro, date_souscription,prog);
                            part1.CreateParticulier();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez un numero de client particulier (2 chiffres)");
                            string No2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom ");
                            string nom2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un prenom");
                            string prenom2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse (numéro,rue,ville)");
                            string adresse2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un téléphone");
                            string tel2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un mail");
                            string date_intro2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de souscription (JJ/MM/AAAA)");
                            string date_souscription2 = Convert.ToString(Console.ReadLine());
                            
                            Particulier part2 = new Particulier(No2, nom2, prenom2, adresse2, tel2, date_intro2, date_souscription2, 0);
                            part2.CreateParticulier();
                            break;
                        case 3:
                            Console.WriteLine("Saisissez le N° de client particulier à supprimer (2 chiffres)");
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Particulier where no_particulier=" + numsupp + ";");
                            Console.WriteLine("Client particulier supprimé");
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
                            Console.WriteLine("Saisissez un numero de client boutique (5 chiffres)");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom ");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse (numéro,rue,Ville");
                            string adresse = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un téléphone");
                            string tel = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un mail");
                            string mail = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un contact");
                            string contact = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une remise");
                            int remise = Convert.ToInt32(Console.ReadLine());
                            
                            Boutique b1 = new Boutique(No, nom, adresse, tel, mail, contact, remise);
                            b1.CreateBoutique();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez un numero de client boutique (5 chiffres)");
                            string No2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom ");
                            string nom2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse (numéro,rue,Ville)");
                            string adresse2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un téléphone");
                            string tel2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un mail");
                            string mail2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un contact");
                            string contact2 = Convert.ToString(Console.ReadLine());
                           

                            Boutique b2 = new Boutique(No2, nom2, adresse2, tel2, mail2, contact2,0);
                            b2.CreateBoutique();
                            break;
                        case 3:
                            Console.WriteLine("Saisissez le nom du client boutique à supprimer");
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Boutique where nom_boutique=" + numsupp + ";");
                            Console.WriteLine("Client boutique supprimé");
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
                            Console.WriteLine("Saisissez un siret de fournisseur (14 chiffres)");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un nom de fournisseur ");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez un contact" );
                            string contact = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse (numéro,rue,ville)");
                            string adresse = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une note (1,2,3,4)");
                            int note = Convert.ToInt32(Console.ReadLine());
                            
                            Fournisseur f1 = new Fournisseur(No, nom, contact, adresse, note);
                            f1.CreateFournisseur();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez le nom du fournisseur à supprimer");
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Fournisseur where nom_fournisseur=" + numsupp + ";");
                            Console.WriteLine("Fournisseur supprimé");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                      
                    }
                    break;
                case 6:
                    Console.WriteLine("Que souhaitez vous faire ?");
                    Console.WriteLine("1. Création d'une commande \n2. Suppression d'une commande \n3. MAJ d'une commande");
                    int caseSwitch7 = Convert.ToInt32(Console.ReadLine());
                    switch (caseSwitch7)
                    {
                        case 1:
                            Console.WriteLine("Saisissez un numéro de commande (5 chiffres)");
                            string No = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de commande (JJ/MM/AAAA) ");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une adresse de livraison (numéro,rue,ville)");
                            string ad_livraison = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Saisissez une date de livraison (JJ/MM/AAAA)");
                            string date_livr = Convert.ToString(Console.ReadLine());

                            Commande c1 = new Commande(No, nom, ad_livraison, date_livr);
                            c1.CreateCommande();
                            break;
                        case 2:
                            Console.WriteLine("Saisissez le numéro de la commande à supprimer (5 chiffres)");
                            string numsupp = Convert.ToString(Console.ReadLine());
                            Connection.update("delete from Commande where no_commande=" + numsupp + ";");
                            Console.WriteLine("Commande supprimée");
                            break;
                        case 3:
                            Console.WriteLine("no");
                            break;
                        
                    }
                    break;
                    
            }

            
            
            Console.ReadKey();
        }
    }
}
