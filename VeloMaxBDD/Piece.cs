using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace VeloMaxBDD
{
    class Piece
    {
        // Attributs d'instance
        int no_piece;
        string desc_piece;
        string date_intro_piece;
        string date_disco_piece;
        int stock;

        public Piece(int no_piece, string desc_piece, string date_intro_piece, string date_disco_piece, int stock)
        {
            this.no_piece = no_piece;
            this.desc_piece = desc_piece;
            this.date_intro_piece = date_intro_piece;
            this.date_disco_piece = date_disco_piece;
            this.stock = stock;
        }
        public int No_piece
        {
            get { return no_piece; }
            set
            {
                no_piece = value;
                Connection.update("update piece set no_piece=" + value + " where no_piece=" + no_piece);
            }
        }
        public string Desc_piece
        {
            get { return desc_piece; }
            set
            {
                desc_piece = value;
                Connection.update("update piece set desc_piece=" + value + " where no_piece=" +no_piece+";");
            }
        }
        public string Date_intro_piece
        {
            get { return date_intro_piece; }
            set
            {
                date_intro_piece = value;
                Connection.update("update piece set date_intro_piece=" + value + " where no_piece=" + no_piece + ";");
            }
        }
        public string Date_disco_piece
        {
            get { return date_disco_piece; }
            set
            {
                date_disco_piece = value;
                Connection.update("update piece set date_disco_piece=" + value + " where no_piece=" + no_piece + ";");
            }
        }
        public int Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                Connection.update("update piece stock=" + value + " where no_piece=" + no_piece + ";");
            }
        }
        
        public void CreatePiece()
        {
            
            Connection.update($"insert into Piece values ('{no_piece}','{desc_piece}',{date_intro_piece}',{date_disco_piece}','{stock}');");
            Console.WriteLine("Voici la pièce créée : \n");
            Connection.select("select * from Piece where no_piece="+ no_piece+ ";");
        }
    }
}
