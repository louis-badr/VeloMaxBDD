using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VeloMaxBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            #region //Connection début
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
            #endregion


            Choix_interface(connexion);

            connexion.Close();
            Console.ReadKey();


        }
        static void AffichageListModele()
        {

        }
        static void Choix_interface(MySqlConnection connexion)
        {
            #region // lecture de la table pièce
            List<Piece> listePieces = new List<Piece>();
            string requete = "Select * from piece;";
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount / 5; i = i + 5)
                {
                    listePieces.Add(new Piece(reader.GetValue(i).ToString(), reader.GetValue(i + 1).ToString(), reader.GetValue(i + 2).ToString(), reader.GetValue(i + 3).ToString(), Convert.ToInt32(reader.GetValue(i + 4).ToString())));
                }
            }
            reader.Close();
            command.Dispose();
            /*
            foreach (Piece piece in listePieces)
            { 
                Console.WriteLine(piece.No_piece + " | " + piece.Desc_piece + " | " + piece.Date_intro_piece + " | " + piece.Date_disco_piece + " | " + piece.Stock);
            }*/
            #endregion
            #region // lecture de la table fournisseur

            List<Fournisseur> listeFournisseurs = new List<Fournisseur>();
            string requete2 = "Select * from fournisseur;";
            MySqlCommand command2 = connexion.CreateCommand();
            command2.CommandText = requete2;
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                for (int i = 0; i < reader2.FieldCount / 5; i = i + 5)
                {
                    listeFournisseurs.Add(new Fournisseur(reader2.GetValue(i).ToString(), reader2.GetValue(i + 1).ToString(), reader2.GetValue(i + 2).ToString(), reader2.GetValue(i + 3).ToString(), Convert.ToInt32(reader2.GetValue(i + 4).ToString())));
                }
            }
            reader2.Close();
            command2.Dispose();
            /*
            foreach(Fournisseur fournisseur in listeFournisseurs)
            {
                Console.WriteLine(fournisseur.Siret_fournisseur+ " | " + fournisseur.Nom_fournisseur+ " | " + fournisseur.Contact_fournisseur+ " | " + fournisseur.Adresse_fournisseur+ " | " + fournisseur.Note_fournisseur);
            }*/
            #endregion
            #region // lecture de la table boutique
            List<Boutique> listeBoutiques = new List<Boutique>();
            string requete3 = "Select * from boutique;";
            MySqlCommand command3 = connexion.CreateCommand();
            command3.CommandText = requete3;
            MySqlDataReader reader3;
            reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                for (int i = 0; i < reader3.FieldCount / 7; i = i + 7)
                {
                    listeBoutiques.Add(new Boutique(reader3.GetValue(i).ToString(), reader3.GetValue(i + 1).ToString(), reader3.GetValue(i + 2).ToString(), reader3.GetValue(i + 3).ToString(), reader3.GetValue(i + 4).ToString(), reader3.GetValue(i + 5).ToString(), Convert.ToInt32(reader3.GetValue(i + 6).ToString())));
                }
            }
            reader3.Close();
            command3.Dispose();
            /*
            foreach (Boutique boutique in listeBoutiques)
            {
                Console.WriteLine(boutique.No_boutique + " | " + boutique.Nom_boutique + " | " + boutique.Adresse_boutique + " | " + boutique.Tel_boutique + " | " + boutique.Mail_boutique + " | " + boutique.Contact_boutique + " | " + boutique.Remise_boutique);
            }*/
            #endregion

            #region // lecture de la table commande
            List<Commande> listeCommandes = new List<Commande>();
            string requete4 = "Select * from commande;";
            MySqlCommand command4 = connexion.CreateCommand();
            command4.CommandText = requete4;
            MySqlDataReader reader4;
            reader4 = command4.ExecuteReader();

            while (reader4.Read())
            {
                for (int i = 0; i < reader4.FieldCount / 4; i = i + 4)
                {
                    listeCommandes.Add(new Commande(reader4.GetValue(i).ToString(), reader4.GetValue(i + 1).ToString(), reader4.GetValue(i + 2).ToString(), reader4.GetValue(i + 3).ToString()));
                }
            }
            reader4.Close();
            command4.Dispose();
            /*
            foreach (Commande commande in listeCommandes)
            {
                Console.WriteLine(commande.No_commande + " | " + commande.Date_commande + " | " + commande.Adresse_livraison + " | " + commande.Date_livraison);
            }*/
            #endregion

            #region // lecture de la table modele
            List<Modele> listeModeles = new List<Modele>();
            string requete5 = "Select * from modele;";
            MySqlCommand command5 = connexion.CreateCommand();
            command5.CommandText = requete5;
            MySqlDataReader reader5;
            reader5 = command5.ExecuteReader();

            while (reader5.Read())
            {
                for (int i = 0; i < reader5.FieldCount / 7; i = i + 7)
                {
                    listeModeles.Add(new Modele(reader5.GetValue(i).ToString(), reader5.GetValue(i + 1).ToString(), reader5.GetValue(i + 2).ToString(), Convert.ToInt32(reader5.GetValue(i + 3).ToString()), reader5.GetValue(i + 4).ToString(), reader5.GetValue(i + 5).ToString(), reader5.GetValue(i + 6).ToString()));
                }
            }
            reader5.Close();
            command5.Dispose();
            /*
            foreach (Modele modele in listeModeles)
            {
                Console.WriteLine(modele.No_modele + " | " + modele.Nom_modele + " | " + modele.Grandeur + " | " + modele.Prix_modele + " | " + modele.Ligne + " | " + modele.Date_intro_modele + " | " + modele.Date_disco_modele);
            }*/
            #endregion

            #region // lecture de la table particulier
            List<Particulier> listeParticuliers = new List<Particulier>();
            string requete6 = "Select * from particulier;";
            MySqlCommand command6 = connexion.CreateCommand();
            command6.CommandText = requete6;
            MySqlDataReader reader6;
            reader6 = command6.ExecuteReader();

            while (reader6.Read())
            {
                for (int i = 0; i < reader6.FieldCount / 7; i = i + 7)
                {
                    listeParticuliers.Add(new Particulier(Convert.ToInt32(reader6.GetValue(i).ToString()), reader6.GetValue(i + 1).ToString(), reader6.GetValue(i + 2).ToString(), reader6.GetValue(i + 3).ToString(), reader6.GetValue(i + 4).ToString(), reader6.GetValue(i + 5).ToString(), reader6.GetValue(i + 6).ToString(), Convert.ToInt32(reader6.GetValue(i + 7).ToString())));
                }
            }
            reader6.Close();
            command6.Dispose();
            /*
            foreach (Particulier particulier in listeParticuliers)
            {
                Console.WriteLine(particulier.No_particulier + " | " + particulier.Nom_particulier + " | " + particulier.Prenom_particulier + " | " + particulier.Adresse_particulier + " | " + particulier.Tel_particulier + " | " + particulier.Mail_particulier + " | " + particulier.Date_souscription + " | " + particulier.No_programme);
            }*/
            #endregion
            bool quit = false;
            while (quit == false)
            {
                Console.WriteLine("Que souhaitez vous faire ?");
                Console.WriteLine("1. Gestion des pièces\n2. Gestion des vélos \n3. Gestion des clients particuliers \n4. Gestion des clients boutique \n5. Gestion des fournisseurs \n6. Gestion des commandes \n7. Quitter");
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
                                listePieces.Add(p1);
                                Console.WriteLine();
                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Saisissez le N° de pièce à supprimer");
                                string numsupp = Convert.ToString(Console.ReadLine());
                                Connection.update($"delete from Piece where no_piece=  '{numsupp}' ;");
                                listePieces.Remove(listePieces.Find(x => x.No_piece == numsupp));
                                Console.WriteLine("Pièce supprimée");
                                Console.WriteLine();
                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 3:
                                foreach (Piece piece in listePieces)
                                {
                                    Console.WriteLine(piece.ToString());
                                }
                                Console.WriteLine("Entrez le N° de pièce que vous voulez modifier :");
                                string nummodif = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° Piece \n2. Description \n3. Date introduction \n4. Date discontinuation \n5. Stock");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° de pièce");

                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Piece set no_piece= '{numpiece}' where no_piece= '{nummodif}';");
                                    int index = listePieces.FindIndex(x => x.No_piece == nummodif);
                                    listePieces[index].No_piece = numpiece;
                                    Console.WriteLine("Pièce modifiée");
                                    Console.WriteLine(listePieces[index].ToString());
                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez la nouvelle description de pièce");
                                    string descpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Piece set desc_piece= '{descpiece}' where no_piece= '{nummodif}';");
                                    int index = listePieces.FindIndex(x => x.No_piece == nummodif);
                                    listePieces[index].Desc_piece = descpiece;
                                    Console.WriteLine("Pièce modifiée");
                                    Console.WriteLine(listePieces[index].ToString());
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez la nouvelle date d'introduction (JJ/MM/AAAA)");
                                    string dateintroupdate = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Piece set date_intro_piece= '{dateintroupdate}' where no_piece= '{nummodif}';");
                                    int index = listePieces.FindIndex(x => x.No_piece == nummodif);
                                    listePieces[index].Date_intro_piece = dateintroupdate;
                                    Console.WriteLine("Pièce modifiée");
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez la nouvelle date de discontinuité (JJ/MM/AAAA)");
                                    string datediscoupdate = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Piece set date_disco_piece= '{datediscoupdate}' where no_piece= '{nummodif}';");
                                    int index = listePieces.FindIndex(x => x.No_piece == nummodif);
                                    listePieces[index].Date_disco_piece = datediscoupdate;
                                    Console.WriteLine("Pièce modifiée");
                                }
                                if (key == 5)
                                {

                                    Console.WriteLine("Entrez le nouveau stock de pièce");
                                    int stockupdate = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Piece set stock= '{stockupdate}' where no_piece= '{nummodif}';");
                                    int index = listePieces.FindIndex(x => x.No_piece == nummodif);
                                    listePieces[index].Stock = stockupdate;
                                    Console.WriteLine(listePieces[index].ToString());
                                    Console.WriteLine("Pièce modifiée");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
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
                                Modele m1 = new Modele(No, nom, grandeur, prix, ligne, date_intro, date_disco);
                                m1.CreateModele();
                                listeModeles.Add(m1);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Saisissez le N° du modele à supprimer (3 chiffres)");
                                string numsupp = Convert.ToString(Console.ReadLine());
                                Connection.update($"delete from Modele where no_modele=  '{numsupp}'  ;");
                                listeModeles.Remove(listeModeles.Find(x => x.No_modele == numsupp));
                                Console.WriteLine("Modèle supprimé");
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine("Entrez le N° du modèle que vous voulez modifier :");
                                string nummodif = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° modele \n2. Nom modèle \n3. Grandeur \n4. Prix \n5. Ligne \n6. Date d'introduction \n7. Date de discontinuité");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° de modèle (3 chiffres)");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set no_modele= '{numpiece}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].No_modele = numpiece;
                                    Console.WriteLine("Modèle modifié");

                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez le nouveau nom modèle");
                                    string descpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set nom_modele= '{descpiece}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Nom_modele = descpiece;
                                    Console.WriteLine("Modèle modifié");
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez la nouvelle grandeur");
                                    string grandeurupdate = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set grandeur= '{grandeurupdate}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Grandeur = grandeurupdate;
                                    Console.WriteLine("Modèle modifié");
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez le nouveau prix");
                                    int prixup = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Modèle set prix_modele= '{prixup}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Prix_modele = prixup;
                                    Console.WriteLine("Modèle modifié");
                                }
                                if (key == 5)
                                {

                                    Console.WriteLine("Entrez la nouvelle ligne");
                                    string ligneup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set ligne= '{ligneup}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Ligne = ligneup;
                                    Console.WriteLine("Modèle modifié");
                                }
                                if (key == 6)
                                {

                                    Console.WriteLine("Entrez la nouvelle date d'introduction (JJ/MM/AAAA)");
                                    string dateintroup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set date_intro_modele= '{dateintroup}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Date_intro_modele = dateintroup;
                                    Console.WriteLine("Modèle modifié");
                                }
                                if (key == 7)
                                {

                                    Console.WriteLine("Entrez la nouvelle date de discontinuité (JJ/MM/AAAA)");
                                    string datediscoup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Modele set date_disco_modele= '{datediscoup}' where no_modele= '{nummodif}';");
                                    int index = listeModeles.FindIndex(x => x.No_modele == nummodif);
                                    listeModeles[index].Date_disco_modele = datediscoup;
                                    Console.WriteLine("Modèle modifié");
                                }
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
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
                                Console.WriteLine("Saisissez un numero de client particulier (chiffres)");
                                int No = Convert.ToInt32(Console.ReadLine());
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
                                Particulier part1 = new Particulier(No, nom, prenom, adresse, tel, date_intro, date_souscription, prog);
                                part1.CreateParticulier();
                                listeParticuliers.Add(part1);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Saisissez un numero de client particulier (chiffres)");
                                int No2 = Convert.ToInt32(Console.ReadLine());
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
                                listeParticuliers.Add(part2);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine("Saisissez le N° de client particulier à supprimer (chiffres)");
                                int numsupp = Convert.ToInt32(Console.ReadLine());
                                Connection.update($"delete from Particulier where no_particulier= '{numsupp}'  ;");
                                listeParticuliers.Remove(listeParticuliers.Find(x => x.No_particulier == numsupp));
                                Console.WriteLine("Client particulier supprimé");
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 4:
                                Console.WriteLine("Entrez le N° de client particulier que vous voulez modifier (chiffres) :");
                                int nummodif = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° client \n2. Nom client \n3. Prenom client \n4. Adresse client \n5. Tel client \n6. Mail client \n7. Date souscription \n8. N° programme");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° de client (chiffres)");
                                    int numpiece = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Particulier set no_particulier= '{numpiece}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].No_particulier = numpiece;
                                    Console.WriteLine("Client modifié");
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez le nouveau nom du client");
                                    string nomup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set nom_particulier= '{nomup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Nom_particulier = nomup;
                                    Console.WriteLine("Client modifié");
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez le nouveau prénom du client");
                                    string prenomup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set prenom_particulier= '{prenomup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Prenom_particulier = prenomup;
                                    Console.WriteLine("Client modifié");
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez la nouvelle adresse du client (numéro,rue,ville)");
                                    string adresseup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set adresse_particulier= '{adresseup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Adresse_particulier = adresseup;
                                    Console.WriteLine("Client modifié");
                                }
                                if (key == 5)
                                {

                                    Console.WriteLine("Entrez le nouveau téléphone du client");
                                    string telup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set tel_particulier= '{telup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Tel_particulier = telup;
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                    Console.WriteLine("Client modifié");
                                }
                                if (key == 6)
                                {

                                    Console.WriteLine("Entrez le nouveau mail du client");
                                    string mailup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set mail_particulier= '{mailup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Mail_particulier = mailup;
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                    Console.WriteLine("Client modifié");
                                }
                                if (key == 7)
                                {

                                    Console.WriteLine("Entrez la nouvelle date de souscription");
                                    string sousc = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Particulier set date_souscription= '{sousc}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].Date_souscription = sousc;
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                    Console.WriteLine("Client modifié");
                                }
                                if (key == 8)
                                {

                                    Console.WriteLine("Entrez le nouveau N° de programme du client");
                                    int progup = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Particulier set no_programme= '{progup}' where no_particulier= '{nummodif}';");
                                    int index = listeParticuliers.FindIndex(x => x.No_particulier == nummodif);
                                    listeParticuliers[index].No_programme = progup;
                                    Console.WriteLine(listeParticuliers[index].ToString());
                                    Console.WriteLine("Client modifié");
                                }
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
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
                                listeBoutiques.Add(b1);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
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


                                Boutique b2 = new Boutique(No2, nom2, adresse2, tel2, mail2, contact2, 0);
                                b2.CreateBoutique();
                                listeBoutiques.Add(b2);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine("Saisissez le nom du client boutique à supprimer");
                                string numsupp = Convert.ToString(Console.ReadLine());
                                Connection.update($"delete from Boutique where nom_boutique=  '{numsupp }' ;");
                                listeBoutiques.Remove(listeBoutiques.Find(x => x.No_boutique == numsupp));
                                Console.WriteLine("Client boutique supprimé");
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 4:
                                Console.WriteLine("Entrez le nom du client boutique que vous voulez modifier :");
                                string nummodif = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° boutique \n2. Nom boutique \n3. Adresse boutique \n4. Téléphone boutique \n5. Mail boutique \n6. Contact boutique \n7. Remise boutique");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° boutique (5 chiffres)");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set no_boutique= '{numpiece}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    Console.WriteLine(index);
                                    //listeBoutiques[index].No_boutique = numpiece;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listePieces[index].ToString());
                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez le nouveau nom boutique");
                                    string nombup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set nom_boutique= '{nombup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Nom_boutique = nombup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez la nouvelle adresse boutique");
                                    string adressbeup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set adresse_boutique= '{adressbeup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Adresse_boutique = adressbeup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez le nouveau téléphone boutique");
                                    string telbup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set tel_boutique= '{telbup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Tel_boutique = telbup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                if (key == 5)
                                {

                                    Console.WriteLine("Entrez le nouveau mail boutique");
                                    string mailup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set mail_boutique= '{mailup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Mail_boutique = mailup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                if (key == 6)
                                {

                                    Console.WriteLine("Entrez le nouveau contact boutique");
                                    string contactup = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Boutique set contact_boutique= '{contactup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Contact_boutique = contactup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                if (key == 7)
                                {

                                    Console.WriteLine("Entrez la nouvelle remise boutique");
                                    int remiseup = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Boutique set remise_boutique= '{remiseup}' where nom_boutique= '{nummodif}';");
                                    int index = listeBoutiques.FindIndex(x => x.Nom_boutique == nummodif);
                                    listeBoutiques[index].Remise_boutique = remiseup;
                                    Console.WriteLine("Boutique modifiée");
                                    Console.WriteLine(listeBoutiques[index].ToString());
                                }
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
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
                                Console.WriteLine("Saisissez un contact");
                                string contact = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez une adresse (numéro,rue,ville)");
                                string adresse = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez une note (1,2,3,4)");
                                int note = Convert.ToInt32(Console.ReadLine());

                                Fournisseur f1 = new Fournisseur(No, nom, contact, adresse, note);
                                f1.CreateFournisseur();
                                listeFournisseurs.Add(f1);
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Saisissez le nom du fournisseur à supprimer");
                                string numsupp = Convert.ToString(Console.ReadLine());
                                Connection.update($"delete from Fournisseur where nom_fournisseur= '{ numsupp}'  ;");
                                listeFournisseurs.Remove(listeFournisseurs.Find(x => x.Nom_fournisseur == numsupp));
                                Console.WriteLine("Fournisseur supprimé");
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine("Entrez le nom du fournisseur que vous voulez modifier :");
                                string nummodif = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° SIRET \n2. Nom fournisseur \n3. Contact fournisseur \n4. Adresse fournisseur \n5. Note fournisseur");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° SIRET");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Fournisseur set siret_fournisseur= '{numpiece}' where nom_fournisseur= '{nummodif}';");
                                    int index = listeFournisseurs.FindIndex(x => x.Nom_fournisseur == nummodif);
                                    listeFournisseurs[index].Siret_fournisseur = numpiece;
                                    Console.WriteLine("Fournisseur modifié");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez le nouveau nom fournisseur");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Fournisseur set nom_fournisseur= '{numpiece}' where nom_fournisseur= '{nummodif}';");
                                    int index = listeFournisseurs.FindIndex(x => x.Nom_fournisseur == nummodif);
                                    listeFournisseurs[index].Nom_fournisseur = numpiece;
                                    Console.WriteLine("Fournisseur modifié");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez le nouveau contact fournisseur");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Fournisseur set contact_fournisseur= '{numpiece}' where nom_fournisseur= '{nummodif}';");
                                    int index = listeFournisseurs.FindIndex(x => x.Nom_fournisseur == nummodif);
                                    listeFournisseurs[index].Contact_fournisseur = numpiece;
                                    Console.WriteLine("Fournisseur modifié");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez la nouvelle adresse fournisseur");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Founrisseur set adresse_fournisseur= '{numpiece}' where nom_fournisseur= '{nummodif}';");
                                    int index = listeFournisseurs.FindIndex(x => x.Nom_fournisseur == nummodif);
                                    listeFournisseurs[index].Adresse_fournisseur = numpiece;
                                    Console.WriteLine("Fournisseur modifié");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 5)
                                {

                                    Console.WriteLine("Entrez la nouvelle note fournisseur");
                                    int numpiece = Convert.ToInt32(Console.ReadLine());
                                    Connection.update($"update Fournisseur set note_fournisseur= '{numpiece}' where nom_fournisseur= '{nummodif}';");
                                    int index = listeFournisseurs.FindIndex(x => x.Nom_fournisseur == nummodif);
                                    listeFournisseurs[index].Note_fournisseur = numpiece;
                                    Console.WriteLine("Fournisseur modifié");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }

                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;

                        }
                        break;
                    case 6:
                        Console.WriteLine("Que souhaitez vous faire ?");
                        Console.WriteLine("1. Création d'une commande pour un usager \n2. Création d'une commande pour une boutique \n3. Suppression d'une commande \n4. MAJ d'une commande");
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
                                Console.WriteLine("Saisissez un numéro de client");
                                int numc = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Saisissez le N° modèle désiré");
                                string mod = Convert.ToString(Console.ReadLine());

                                MySqlCommand commandstock = connexion.CreateCommand();
                                commandstock.CommandText = ($"select p.stock from modele m join Production prod on m.no_modele=prod.no_modele join piece p on prod.no_piece=p.no_piece where m.no_modele='{mod}';");

                                MySqlDataReader readerstock;
                                readerstock = commandstock.ExecuteReader();
                                List<string> listestock = new List<string>();

                                while (readerstock.Read())
                                {
                                    string currentRowAsString = "";
                                    for (int i = 0; i < readerstock.FieldCount; i++)
                                    {
                                        string valueAsString = readerstock.GetValue(i).ToString();
                                        currentRowAsString += valueAsString + ", ";
                                        listestock.Add(currentRowAsString);
                                    }

                                }
                                readerstock.Close();
                                commandstock.Dispose();
                                int stockcheck = 1;
                                foreach (string s in listestock)
                                {
                                    if (s == "0")
                                    {
                                        Console.WriteLine("Il n'y a pas assez de stock, veuillez consulter les stocks");
                                        stockcheck = 0;
                                    }
                                }
                                if (stockcheck == 1)
                                {


                                    Commande c1 = new Commande(No, nom, ad_livraison, date_livr);
                                    c1.CreateCommande();
                                    Connection.update($"insert into devisParticulier values ('{numc}','{No}');");
                                    Connection.update($"insert into commandeModele values ('{No}','{mod}');");
                                    Connection.update($"update Piece p join Production pr on p.no_piece=pr.no_piece join Modele m on pr.no_modele=m.no_modele join commandeModele cm on m.no_modele=cm.no_modele set p.stock = stock - 1 where m.no_modele = '{mod}'; ");
                                    listeCommandes.Add(c1);
                                    Console.WriteLine();

                                    Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                    Console.WriteLine();

                                }
                                break;
                            case 2:
                                Console.WriteLine("Saisissez un numéro de commande (5 chiffres)");
                                string No2 = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez une date de commande (JJ/MM/AAAA) ");
                                string nom2 = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez une adresse de livraison (numéro,rue,ville)");
                                string ad_livraison2 = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez une date de livraison (JJ/MM/AAAA)");
                                string date_livr2 = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Saisissez un numéro de boutique");
                                int numb = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Commande de modèle (1) ou de pièce (2)?");
                                int rep = Convert.ToInt32(Console.ReadLine());
                                if (rep == 1)
                                {
                                    Console.WriteLine("Saisissez un numéro de modèle");
                                    string modb = Convert.ToString(Console.ReadLine());
                                    MySqlCommand commandstock2 = connexion.CreateCommand();
                                    commandstock2.CommandText = ($"select p.stock from modele m join Production prod on m.no_modele=prod.no_modele join piece p on prod.no_piece=p.no_piece where m.no_modele='{modb}';");

                                    MySqlDataReader readerstock2;
                                    readerstock2 = commandstock2.ExecuteReader();
                                    List<string> listestock2 = new List<string>();

                                    while (readerstock2.Read())
                                    {
                                        string currentRowAsString = "";
                                        for (int i = 0; i < readerstock2.FieldCount; i++)
                                        {
                                            string valueAsString = readerstock2.GetValue(i).ToString();
                                            currentRowAsString += valueAsString + ", ";
                                            listestock2.Add(currentRowAsString);
                                        }

                                    }
                                    readerstock2.Close();
                                    commandstock2.Dispose();
                                    int stockcheck2 = 1;
                                    foreach (string s2 in listestock2)
                                    {
                                        if (s2 == "0")
                                        {
                                            Console.WriteLine("Il n'y a pas assez de stock, veuillez consulter les stocks");
                                            stockcheck2 = 0;
                                        }
                                    }
                                    if (stockcheck2 == 1)
                                    {
                                        Commande c5 = new Commande(No2, nom2, ad_livraison2, date_livr2);
                                        c5.CreateCommande();
                                        
                                        Connection.update($"insert into devisBoutique values ('{No2}','{numb}');");
                                        Connection.update($"insert into commandeModele values ('{No2}','{modb}');");

                                        Connection.update($"update Piece p join Production pr on p.no_piece=pr.no_piece join Modele m on pr.no_modele=m.no_modele join commandeModele cm on m.no_modele=cm.no_modele set p.stock = stock - 1 where m.no_modele = '{modb}'; ");
                                        listeCommandes.Add(c5);
                                        
                                    }

                                    Console.WriteLine();

                                    Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                    Console.WriteLine();
                                }
                                if (rep == 2)
                                {
                                    Console.WriteLine("Saisissez un numéro de Pièce");
                                    string pieceb = Convert.ToString(Console.ReadLine());
                                    Console.WriteLine("Saisissez une quantité");
                                    int qte2 = Convert.ToInt32(Console.ReadLine());
                                    MySqlCommand commandstock2 = connexion.CreateCommand();
                                    commandstock2.CommandText = ($"select stock from Piece where no_piece='{pieceb}';");

                                    MySqlDataReader readerstock2;
                                    readerstock2 = commandstock2.ExecuteReader();

                                    int value = 0;
                                    while (readerstock2.Read())
                                    {

                                        for (int i = 0; i < readerstock2.FieldCount; i++)
                                        {
                                            value = Convert.ToInt32(readerstock2.GetValue(i));


                                        }
                                        Console.WriteLine(value);
                                    }
                                    readerstock2.Close();
                                    commandstock2.Dispose();

                                    int stockcheck2 = 1;
                                    if (value < qte2)
                                    {
                                        Console.WriteLine("Il n'y a pas assez de stock pour une telle quantité");
                                        stockcheck2 = 0;
                                    }
                                    if (stockcheck2 == 1)
                                    {
                                        int newval = value - qte2;
                                        Commande c6 = new Commande(No2, nom2, ad_livraison2, date_livr2);
                                        c6.CreateCommande();
                                        
                                        Connection.update($"insert into devisBoutique values ('{No2}','{numb}');");
                                        Connection.update($"insert into commandePiece values ('{No2}','{pieceb}','{qte2}');");
                                        Connection.update($"update Piece set stock='{newval}' where no_piece='{pieceb}';");
                                        listeCommandes.Add(c6);
                                        
                                    }

                                    Console.WriteLine();

                                    Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                    Console.WriteLine();
                                }
                                break;
                            
                                
                            case 3:
                                Console.WriteLine("Saisissez le numéro de la commande à supprimer (5 chiffres)");
                                string numsupp = Convert.ToString(Console.ReadLine());
                                Connection.update($"delete from Commande where no_commande= '{numsupp}' ;");
                                listeCommandes.Remove(listeCommandes.Find(x => x.No_commande == numsupp));
                                Console.WriteLine("Commande supprimée");
                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;
                            case 4:
                                Console.WriteLine("Entrez le N° de commande que vous voulez modifier :");
                                string nummodif = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Que voulez vous modifier ?");
                                Console.WriteLine("1. N° commande \n2. Date commande \n3. Adresse livraison \n4. Date livraison");
                                int key = Convert.ToInt32(Console.ReadLine());
                                if (key == 1)
                                {
                                    Console.WriteLine("Entrez le nouveau N° commande");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Commande set no_commande= '{numpiece}' where no_commande= '{nummodif}';");
                                    int index = listeCommandes.FindIndex(x => x.No_commande == nummodif);
                                    listeCommandes[index].No_commande = numpiece;
                                    Console.WriteLine("Commande modifiée");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 2)
                                {
                                    Console.WriteLine("Entrez la nouvelle date commande");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Commande set date_commande= '{numpiece}' where no_commande= '{nummodif}';");
                                    int index = listeCommandes.FindIndex(x => x.No_commande == nummodif);
                                    listeCommandes[index].Date_commande = numpiece;
                                    Console.WriteLine("Commande modifiée");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 3)
                                {
                                    Console.WriteLine("Entrez la nouvelle adresse de livraison");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Commande set adresse_livraison= '{numpiece}' where no_commande= '{nummodif}';");
                                    int index = listeCommandes.FindIndex(x => x.No_commande == nummodif);
                                    listeCommandes[index].Adresse_livraison = numpiece;
                                    Console.WriteLine("Commande modifiée");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }
                                if (key == 4)
                                {
                                    Console.WriteLine("Entrez la nouvelle date de livraison");
                                    string numpiece = Convert.ToString(Console.ReadLine());
                                    Connection.update($"update Commande set date_livraison= '{numpiece}' where no_commande= '{nummodif}';");
                                    int index = listeCommandes.FindIndex(x => x.No_commande == nummodif);
                                    listeCommandes[index].Date_livraison = numpiece;
                                    Console.WriteLine("Commande modifiée");
                                    Console.WriteLine(listeFournisseurs[index].ToString());
                                }

                                Console.WriteLine();

                                Console.WriteLine("Appuyez sur entrée pour revenir au menu principal");
                                Console.WriteLine();
                                break;

                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;

                }

                Console.ReadKey();
            }

        }
    }
}
