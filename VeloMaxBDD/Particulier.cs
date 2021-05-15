using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMaxBDD
{
    class Particulier
    {
        string no_particulier;
        string nom_particulier;
        string prenom_particulier;
        string adresse_particulier;
        string tel_particulier;
        string mail_particulier;
        string date_souscription;
        int no_programme;

        public Particulier(string no_particulier, string nom_particulier, string prenom_particulier, string adresse_particulier, string tel_particulier, string mail_particulier,string date_souscription, int no_programme)
        {
            this.no_particulier = no_particulier;
            this.nom_particulier = nom_particulier;
            this.prenom_particulier = prenom_particulier;
            this.adresse_particulier = adresse_particulier;
            this.tel_particulier = tel_particulier;
            this.mail_particulier = mail_particulier;
            this.date_souscription = date_souscription;
            this.no_programme = no_programme;

        }
        public string No_particulier
        {
            get { return no_particulier; }
            set
            {
                
                Connection.update($"update Particulier set no_particulier=  '{value}' where no_particulier= '{ no_particulier}';");
                no_particulier = value;
            }

        }
        public string Nom_particulier
        {
            get { return nom_particulier; }
            set
            {
                
                Connection.update($"update Particulier set nom_particulier= '{value}' where nom_particulier= '{nom_particulier}';");
                nom_particulier = value;
            }

        }
        public string Prenom_particulier
        {
            get { return prenom_particulier; }
            set
            {
                
                Connection.update($"update Particulier set prenom_particulier= '{value}'  where prenom_particulier=  '{prenom_particulier}';");
                prenom_particulier = value;
            }

        }
        public string Adresse_particulier
        {
            get { return adresse_particulier; }
            set
            {
                
                Connection.update($"update Particulier set adresse_particulier= '{value}' where adresse_particulier= '{adresse_particulier}';");
                adresse_particulier = value;
            }

        }
        public string Tel_particulier
        {
            get { return tel_particulier; }
            set
            {
                
                Connection.update($"update Particulier set tel_particulier= '{value}'  where tel_particulier=  '{tel_particulier}';");
                tel_particulier = value;
            }

        }
        public string Mail_particulier
        {
            get { return mail_particulier; }
            set
            {
                
                Connection.update($"update Particulier set mail_particulier='{ value}' where mail_particulier= '{ mail_particulier}';");
                mail_particulier = value;
            }

        }
        public string Date_souscription
        {
            get { return date_souscription; }
            set
            {
                
                Connection.update($"update Particulier set date_souscription= '{value}' where date_souscription= '{date_souscription}';");
                date_souscription = value;
            }

        }
        public int No_programme
        {
            get { return no_programme; }
            set
            {
                
                Connection.update($"update Particulier set no_programme= '{value}' where no_programme= '{no_programme}';");
                no_programme = value;
            }

        }
        public void CreateParticulier()
        {

            Connection.update($"insert into Particulier values ('{no_particulier}','{nom_particulier}','{prenom_particulier}','{adresse_particulier}','{tel_particulier}','{mail_particulier}','{date_souscription}','{no_programme}');");
            Console.WriteLine("Voici le particulier créé : \n");
            Connection.select($"select * from Particulier where no_particulier= + '{no_particulier}' + ;");
        }
    }
}
