using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMaxBDD
{
    class Commande
    {
        int no_commande;
        string date_commande;
        string adresse_livraison;
        string date_livraison;
        

        public Commande(int no_commande, string date_commande, string adresse_livraison, string date_livraison)
        {
            this.no_commande = no_commande;
            this.date_commande = date_commande;
            this.adresse_livraison = adresse_livraison;
            this.date_livraison = date_livraison;
      

        }
        public int No_commande
        {
            get { return no_commande; }
            set
            {
                no_commande = value;
                Connection.update("update Commande set no_commande=" + value + " where no_commande=" + no_commande);

            }

        }
        public string Date_commande
        {
            get { return date_commande; }
            set
            {
                date_commande = value;
                Connection.update("update Commande set date_commande=" + value + " where date_commande=" + date_commande);

            }

        }
        public string Adresse_livraison
        {
            get { return adresse_livraison ; }
            set
            {
                adresse_livraison = value;
                Connection.update("update Commande set adresse_livraison=" + value + " where adresse_livraison=" + adresse_livraison);

            }

        }
        public string Date_livraison
        {
            get { return date_livraison; }
            set
            {
                date_livraison = value;
                Connection.update("update Commande set date_livraison=" + value + " where date_livraison=" + date_livraison);

            }

        }
        
        public void CreateCommande()
        {

            Connection.update($"insert into Commande values ('{no_commande}','{date_commande}',{adresse_livraison}',{date_livraison}');");
            Console.WriteLine("Voici la commande créée : \n");
            Connection.select("select * from Commande where no_commande=" + no_commande + ";");
        }
    }
}
