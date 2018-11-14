using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplikaceKod
{
    class Panacek
    {
        public string panacek =
            "  _O_  \n" +
            " |  |  |  \n" +
            " |_|_ |  \n" +
            "°|    |°  \n" +
            " |    |   \n" +
            "^   ^     \n";
        public static string hlava_panacek  = "   _O_   ";
        public static string paze_panacek   = "  |  |  |   ";
        public static string ruce_panacek   = "  |_|_ |   ";
        public static string noha_v_panacek = " °|    |°   ";
        public static string noha_s_panacek = "  |    |    ";
        public static string chodid_panacek = " ^   ^      ";

        public string panacek_slozeny = hlava_panacek + "\n" +
                                        paze_panacek + "\n" + 
                                        ruce_panacek + "\n" +
                                        noha_v_panacek + "\n" +
                                        noha_s_panacek +"\n" +
                                        chodid_panacek + "\n";
        //panacek_slozeny = " ^ ^ \n";
    }
}
