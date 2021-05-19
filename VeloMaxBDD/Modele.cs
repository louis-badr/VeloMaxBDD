using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
namespace VeloMaxBDD
{
    class Modele
    {
        string no_modele;
        string nom_modele;
        string grandeur;
        int prix_modele;
        string ligne;
        string date_intro_modele;
        string date_disco_modele;

        public Modele(string no_modele, string nom_modele, string grandeur, int prix_modele, string ligne, string date_intro_modele, string date_disco_modele)
        {
            this.no_modele = no_modele;
            this.nom_modele = nom_modele;
            this.grandeur = grandeur;
            this.prix_modele = prix_modele;
            this.ligne = ligne;
            this.date_intro_modele = date_intro_modele;
            this.date_disco_modele = date_disco_modele;
        }
        public string No_modele
        {
            get { return no_modele; }
            set
            {
               
                Connection.update($"update Modele set no_modele= '{value}' where no_modele=  '{no_modele}';");
                no_modele = value;
            }
        }
        public string Nom_modele
        {
            get { return nom_modele; }
            set
            {
                
                Connection.update($"update Modele set nom_modele= '{value}' where nom_modele= '{nom_modele}';");
                nom_modele = value;
            }
        }
        public string Grandeur
        {
            get { return grandeur; }
            set
            {
                
                Connection.update($"update Modele set grandeur= '{value}'  where grandeur= '{grandeur}';");
                grandeur = value;
            }
        }
        public int Prix_modele
        {
            get { return prix_modele; }
            set
            {
                
                Connection.update($"update Modele set prix_modele= '{value}' where prix_modele= '{prix_modele}';");
                prix_modele = value;
            }
        }
        public string Ligne
        {
            get { return ligne; }
            set
            {
                
                Connection.update($"update Modele set ligne= '{value}' where ligne= '{ligne}';");
                ligne = value;
            }
        }
        public string Date_intro_modele
        {
            get { return date_intro_modele; }
            set
            {
                
                Connection.update($"update Modele set date_intro_modele= '{value}' where date_intro_modele= '{date_intro_modele}';");
                date_intro_modele = value;
            }
        }
        public string Date_disco_modele
        {
            get { return date_disco_modele; }
            set
            {
                
                Connection.update($"update Modele set date_disco_modele= '{value}' where date_disco_modele= '{date_disco_modele}';");
                date_disco_modele = value;
            }
        }
        public override string ToString()
        {
            return no_modele + " | " + nom_modele + " | " + grandeur + " | " + prix_modele + "euros | " + ligne + " | " + date_intro_modele + " | " + date_disco_modele;
        }
        public void CreateModele()
        {

            Connection.update($"insert into Modele values ('{no_modele}','{nom_modele}',{grandeur}','{prix_modele}','{ligne}','{date_intro_modele}','{date_disco_modele}');");
            Console.WriteLine("Voici le modele créé : \n");
            Connection.select($"select * from Modele where no_modele= '{no_modele}' ;");
        }
    }
}
