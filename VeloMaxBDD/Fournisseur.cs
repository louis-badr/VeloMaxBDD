﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMaxBDD
{
    class Fournisseur
    {
        string siret_fournisseur;
        string nom_fournisseur;
        string contact_fournisseur;
        string adresse_fournisseur;
        int note_fournisseur;

        public Fournisseur(string siret_fournisseur, string nom_fournisseur, string contact_fournisseur, string adresse_fournisseur, int note_fournisseur)
        {
            this.siret_fournisseur = siret_fournisseur;
            this.nom_fournisseur = nom_fournisseur;
            this.contact_fournisseur = contact_fournisseur;
            this.adresse_fournisseur = adresse_fournisseur;
            this.note_fournisseur = note_fournisseur;
            
        }
        public string Siret_fournisseur
        {
            get { return siret_fournisseur; }
            set
            {
                siret_fournisseur = value;
                Connection.update("update Fournisseur set siret_fournisseur=" + value + " where siret_fournisseur=" + siret_fournisseur);

            }

        }
        public string Nom_fournisseur
        {
            get { return nom_fournisseur; }
            set
            {
                nom_fournisseur = value;
                Connection.update("update Fournisseur set nom_fournisseur=" + value + " where nom_fournisseur=" + nom_fournisseur);

            }

        }
        public string Contact_fournisseur
        {
            get { return contact_fournisseur; }
            set
            {
                contact_fournisseur = value;
                Connection.update("update Fournisseur set contact_fournisseur=" + value + " where contact_fournisseur=" + contact_fournisseur);

            }

        }
        public string Adresse_fournisseur
        {
            get { return adresse_fournisseur; }
            set
            {
                adresse_fournisseur = value;
                Connection.update("update Fournisseur set adresse_fournisseur=" + value + " where adresse_fournisseur=" + adresse_fournisseur);

            }

        }
        public int Note_fournisseur
        {
            get { return note_fournisseur; }
            set
            {
                note_fournisseur = value;
                Connection.update("update Fournisseur set note_fournisseur=" + value + " where note_fournisseur=" + note_fournisseur);

            }

        }
        public void CreateFournisseur()
        {

            Connection.update($"insert into Fournisseur values ('{siret_fournisseur}','{nom_fournisseur}',{contact_fournisseur}',{adresse_fournisseur}','{note_fournisseur}');");
            Console.WriteLine("Voici le fournisseur créé : \n");
            Connection.select("select * from Fournisseur where nom_fournisseur=" + nom_fournisseur + ";");
        }
    }
}