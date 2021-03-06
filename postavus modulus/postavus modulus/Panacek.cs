﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    public class Panacek
    {
        public List<string> postava = new List<string>();
        public string panacek;

        public Stats Health = new Stats()
        {
            velikost = 8,
            stat = Statistika.Život
        };
        public Stats Max_Health = new Stats()
        {
            velikost = 10,
            stat = Statistika.Život
        };
        public Stats Mana = new Stats()
        {
            velikost = 3,
            stat = Statistika.Mana
        };
        public Stats Max_Mana = new Stats()
        {
            velikost = 10,
            stat = Statistika.Život
        };
        public Stats Energie = new Stats()
        {
            velikost = 6,
            stat = Statistika.Energie
        };
        public Stats Max_Energie = new Stats()
        {
            velikost = 10,
            stat = Statistika.Energie
        };


        public Helma helma = new Helma();
        public Telo telo = new Telo();
        public Stit stit = new Stit();
        public Zbran zbran = new Zbran();
        public Nohy nohy = new Nohy();
        public Boty boty = new Boty();


         public Panacek()
        {
            postava.Add("                   ");
            postava.Add("              _      ");
            postava.Add("            /O\\    ");
            postava.Add("              |       |");
            postava.Add("          /XXX\\  |");
            postava.Add("     ---  ||X||   _");
            postava.Add("     |S|-((X))--3");
            postava.Add("      V   -----   ");
            postava.Add("           ||   ||   ");
            postava.Add("           ||   ||   ");
            postava.Add("           ||   ||   ");
            postava.Add("      ×xX    Xx×  ");
            
            panacek = postava[0] + "\n" +
                      postava[1] + "\n" +
                      postava[2] + "\n" +
                      postava[3] + "\n" +
                      postava[4] + "\n" +
                      postava[5] + "\n" +
                      postava[6] + "\n" +
                      postava[7] + "\n" +
                      postava[8] + "\n" +
                      postava[9] + "\n" +
                      postava[10] + "\n" +
                      postava[11] + "\n" ;
        }
        
    }
}
