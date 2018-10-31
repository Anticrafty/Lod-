using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionar.Classy
{
    class Otaznikovec
    {
        public List<Uroven> Urovne = new List<Uroven>();

        public void PriStartuLoad()
        {
            for (int Uroven = 1; Uroven < 16; Uroven++)
            {
                Uroven uroven = new Uroven();
                this.Urovne.Add(uroven);
            }

            //1
            Otazka otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            Odpoved jedna = new Odpoved
            {
                zneni = "1",
                pravdive = true
            };
            otazka1.moznosti.Add(jedna);
            Odpoved dva = new Odpoved
            {
                zneni = "2",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            Odpoved tri = new Odpoved
            {
                zneni = "3",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            Odpoved ctyri = new Odpoved
            {
                zneni = "4",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[0].Otazky.Add(otazka1);

            //2
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "1",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "2",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "3",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "4",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[1].Otazky.Add(otazka1);

            //3
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "1",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "2",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "3",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "4",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[2].Otazky.Add(otazka1);

            //4
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "3",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "4",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "5",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "6",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[3].Otazky.Add(otazka1);

            //5
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "3",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "4",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "5",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "6",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[4].Otazky.Add(otazka1);

            //6
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "5",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "6",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "7",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "8",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[5].Otazky.Add(otazka1);

            //7
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "5",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "6",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "7",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "8",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[6].Otazky.Add(otazka1);

            //8
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "7",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "8",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "9",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "10",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[7].Otazky.Add(otazka1);

            //9
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "7",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "8",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "9",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "10",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[8].Otazky.Add(otazka1);

            //10
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "9",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "10",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "11",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "12",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[9].Otazky.Add(otazka1);

            //11
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "9",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "10",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "11",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "12",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[10].Otazky.Add(otazka1);

            //12
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "11",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "12",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "13",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "14",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[11].Otazky.Add(otazka1);

            //13
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "11",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "12",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "13",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "14",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[12].Otazky.Add(otazka1);

            //14
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "13",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "14",
                pravdive = true
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "15",
                pravdive = false
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "16",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[13].Otazky.Add(otazka1);

            //15
            otazka1 = new Otazka()
            {
                zneni = "Kolikata je toto otazka?",
                moznosti = new List<Odpoved>(),

            };
            // odpovedi 
            jedna = new Odpoved
            {
                zneni = "13",
                pravdive = false
            };
            otazka1.moznosti.Add(jedna);
            dva = new Odpoved
            {
                zneni = "14",
                pravdive = false
            };
            otazka1.moznosti.Add(dva);
            tri = new Odpoved
            {
                zneni = "15",
                pravdive = true
            };
            otazka1.moznosti.Add(tri);
            ctyri = new Odpoved
            {
                zneni = "16",
                pravdive = false
            };
            otazka1.moznosti.Add(ctyri);
            this.Urovne[14].Otazky.Add(otazka1);
        }
    }
}
