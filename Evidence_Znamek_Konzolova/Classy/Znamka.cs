using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Classy
{
    public class Znamka
    {
        [PrimaryKey, AutoIncrement]
        public int ID   { get; set; }
        [Indexed]
        public string predmet { get; set; }
        public int známka { get; set; }
        public int vaha { get; set; }
    }
}
