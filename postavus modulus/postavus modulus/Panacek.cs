using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    class Panacek
    {
        public List<string> postava = new List<string>();
        public string panacek;

        public Helma helma = new Helma();
        public Telo telo = new Telo();
        public Stit stit = new Stit();
        public Mec mec = new Mec();
        public Nohy nohy = new Nohy();
        public Boty boty = new Boty();


         public Panacek()
        {
            postava.Add("                   ");
            postava.Add("              _      ");
            postava.Add("            /O\\    ");
            postava.Add("               |        |");
            postava.Add("          /XXX\\  |");
            postava.Add("     ---  ||X||   _");
            postava.Add("     |S|-((X))--3");
            postava.Add("      V   -----   ");
            postava.Add("            ||  ||   ");
            postava.Add("            ||  ||   ");
            postava.Add("            ||  ||   ");
            postava.Add("   ×xX     Xx×  ");
            
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
