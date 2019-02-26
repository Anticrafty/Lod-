using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Classy
{
    public class Predmet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public string Jmeno { get; set; }
    }
}
