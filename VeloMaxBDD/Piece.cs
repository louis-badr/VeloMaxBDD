using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

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
        }
        public string Desc_piece
        {
            get { return desc_piece; }
        }
        public string Date_intro_piece
        {
            get { return date_intro_piece; }
        }
        public string Date_disco_piece
        {
            get { return date_disco_piece; }
        }
        public int Stock
        {
            get { return stock; }
        }
        public void set_no_piece()
        {

        }
        public void set_desc_piece()
        {

        }
        public void set_date_intro_piece()
        {

        }
        public void set_date_disco_piece()
        {

        }
        public void set_stock()
        {

        }
    }
}
