using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMaxBDD
{
    class Boutique
    {
        string no_boutique;
        string nom_boutique;
        string adresse_boutique;
        string tel_boutique;
        string mail_boutique;
        string contact_boutique;
        int remise_boutique;

        public Boutique(string no_boutique, string nom_boutique, string adresse_boutique, string tel_boutique, string mail_boutique, string contact_boutique, int remise_boutique)
        {
            this.no_boutique = no_boutique;
            this.nom_boutique = nom_boutique;
            this.adresse_boutique = adresse_boutique;
            this.tel_boutique = tel_boutique;
            this.mail_boutique = mail_boutique;
            this.contact_boutique = contact_boutique;
            this.remise_boutique = remise_boutique;

        }
        public string No_boutique
        {
            get { return no_boutique; }
            set
            {
                no_boutique = value;
                Connection.update($"update Boutique set no_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public string Nom_boutique
        {
            get { return nom_boutique; }
            set
            {
                nom_boutique = value;
                Connection.update($"update Boutique set nom_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public string Adresse_boutique
        {
            get { return adresse_boutique; }
            set
            {
                adresse_boutique = value;
                Connection.update($"update Boutique set adresse_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public string Tel_boutique
        {
            get { return tel_boutique; }
            set
            {
                tel_boutique = value;
                Connection.update($"update Boutique set tel_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public string Mail_boutique
        {
            get { return mail_boutique; }
            set
            {
                mail_boutique = value;
                Connection.update($"update Boutique set mail_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public string Contact_boutique
        {
            get { return contact_boutique; }
            set
            {
                contact_boutique = value;
                Connection.update($"update Boutique set contact_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public int Remise_boutique
        {
            get { return remise_boutique; }
            set
            {
                remise_boutique = value;
                Connection.update($"update Boutique set remise_boutique= '{value}' where no_boutique= '{no_boutique}';");

            }

        }
        public override string ToString()
        {
            return no_boutique + " | " + nom_boutique + " | " + adresse_boutique + " | " + tel_boutique + " | " + mail_boutique + " | " + contact_boutique + " | " + remise_boutique;
        }
        public void CreateBoutique()
        {

            Connection.update($"insert into Boutique values ('{no_boutique}','{nom_boutique}',{adresse_boutique}',{tel_boutique}','{mail_boutique}','{contact_boutique}','{remise_boutique}');");
            Console.WriteLine("Voici la boutique créée : \n");
            Connection.select($"select * from Boutique where nom_boutique= '{nom_boutique}';");
        }
    }
}
