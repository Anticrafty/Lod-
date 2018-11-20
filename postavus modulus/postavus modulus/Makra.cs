using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    class Makra
    {
        public List<string> codes = new List<string>();

        public void LoadMacros()
        {
            bool load = true;
            for (int x = 1;load; x++ )
            { 
                string X = x.ToString();

                try
                {


                    // ŠKOLNÍ
                    string souradnice = @"D:\novakja16\Github\postavus modulus\Macra\Macro ("+X+").txt";

                    // NORMAND

                    //string souradnice = @"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\postavus modulus\Macra\Macro (" + X + ").txt";
                    string UserFromFile = File.ReadAllText(souradnice);
                    codes.Add(UserFromFile);
                }
                catch (FileNotFoundException)
                {
                    load = false;
                }
            }
        }
    }
}
