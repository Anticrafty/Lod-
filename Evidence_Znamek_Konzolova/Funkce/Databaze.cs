using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using Classy;

namespace Funkce
{
    public enum Odesilatel { Console, Android}
    public class Databaze
    {
       public SQLiteConnection db;

        public Databaze(string path,Odesilatel odesilatel)
        {

            CreateDBTable(path,odesilatel);

        }
        public void CreateDBTable(string path, Odesilatel odesilatel)
        {
            if (string.IsNullOrEmpty(path))
            {
                if(odesilatel == Odesilatel.Console)
                {
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Znamky.db");
                }
                else if(odesilatel == Odesilatel.Android)
                {
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Znamky.db");
                }
                    
                    
            }
                
            db = new SQLiteConnection(path);
            db.CreateTable<Predmet>();
            db.CreateTable<Znamka>();              
            
        }
        public void Add_znamka(Znamka znamka)
        {
            db.Insert(znamka);
        }

        public List<Znamka> Get_znamky(string where)
        {
            
            return db.Table<Znamka>().Where(s => s.predmet == where).ToList();
        }

        public void Add_predmet(Predmet predmet)
        {
            db.Insert(predmet);
        }

        public List<Predmet> Get_predmety()
        {

            return db.Table<Predmet>().ToList();
        }
    }
}
