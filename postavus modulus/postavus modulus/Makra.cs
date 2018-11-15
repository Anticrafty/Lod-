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
        List<string> code = new List<string>();

        public void LoadMacros()
        {
            bool load = true;
            for (int x = 0;load; x++ )
            { 
                string X = x.ToString();

                try
                { 
                // ŠKOLNÍ
                    //string UserFromFile = File.ReadAllText(@"D:\novakja16\Github\postavus moduslust\Macro ("+X+").txt");

                    // NORMAND
                    string UserFromFile = File.ReadAllText((@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\postavus moduslust\Macro ("+X+").txt"));
                    code.Add(UserFromFile);
                }
                catch (DirectoryNotFoundException)
                {
                    load = false;
                }
            }
        }
    }
}
