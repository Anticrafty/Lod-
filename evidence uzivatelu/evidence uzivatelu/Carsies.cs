using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Carsies
    {
        List<Car> Cars = new List<Car>();

        public bool RemoveCar(string removedSPZ)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID = 0;
            foreach (Car car in Cars)
            {
                if (removedSPZ == car.SPZ )
                {
                    neninikdopodobny = false;

                    nicenaknihaID = IDknihy;
                }
                IDknihy++;
            }
            if (neninikdopodobny)
            {
                Console.WriteLine("Toto Auto v listu neni.");
                return false;
            }
            else
            {
                Cars.Remove(Cars[nicenaknihaID]);
                Console.WriteLine("Auto bylo smazáno");
                return true;

            }
        }

        public bool AddCar(Car newcar)
        {
            bool neninikdopodobny = true;
            foreach (Car car in Cars)
            {
                if (newcar.SPZ == car.SPZ)
                {
                    neninikdopodobny = false;
                }
            }
            if (neninikdopodobny)
            {
                Cars.Add(newcar);
                Console.WriteLine("Auto bylo Vložena");
                return true;
            }
            else
            {
                Console.WriteLine("Toto Auto už v listu je.");
                return false;
            }

        }
    }
}
