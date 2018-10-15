using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void SaveCars()
        {
            // ŠKOLNÍ
            //var file = new FileInfo(@"D:\novakja16\Github\evidence uzivatelu\Cars.xlsx");

            // NORMAND
            var file = new FileInfo(@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\evidence uzivatelu\Cars.xlsx");

            // EMIL
            using (var newExel = new ExcelPackage(file))
            {
                var stranka = newExel.Workbook.Worksheets["Cars"];
                int IDAuta = 0;
                foreach (Car auto in Cars)
                {
                    stranka.Cells[1, IDAuta + 2].Value = IDAuta;
                    stranka.Cells[2, IDAuta + 2].Value = auto.Znacka;
                    stranka.Cells[3, IDAuta + 2].Value = auto.SPZ;
                    stranka.Cells[4, IDAuta + 2].Value = auto.Cena;
                    stranka.Cells[5, IDAuta + 2].Value = auto.NajeteKM;

                    stranka.Cells[1, IDAuta + 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    stranka.Cells[5, IDAuta + 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                    IDAuta++;
                }
                stranka.Cells[1, IDAuta + 1, 5, IDAuta + 1].Style.Border.Right.Style = ExcelBorderStyle.Thick;
                // ŠKOLNÍ
                //var newExel.Save();

                // NORMAND
                newExel.Save();

                // EMIL
            }
        }

        public void LoadCars()
        {
            // ŠKOLNÍ
            //var file = new FileInfo(@"D:\novakja16\Github\evidence uzivatelu\Cars.xlsx");

            // NORMAND
            var file = new FileInfo(@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\evidence uzivatelu\Cars.xlsx");

            // EMIL
           
            if (file.Exists)
            {

            }
            else
            {
                CreateFileForSave();
            }
        }

        public void CreateFileForSave()
        {
            Console.WriteLine("Nejsou uloženy žádný informace dodávam inprovizované");
            using (var newExel = new ExcelPackage())
            {
                var stranka = newExel.Workbook.Worksheets.Add("Cars");

                stranka.Cells[1, 1].Value = "ID";
                stranka.Cells[2, 1].Value = "Značka";
                stranka.Cells[3, 1].Value = "SPZ";
                stranka.Cells[4, 1].Value = "Cena";
                stranka.Cells[5, 1].Value = "najeté KM";

                using (var range = stranka.Cells[1, 1, 5, 1])
                {
                    range.Style.Font.Bold = true;
                }
                stranka.Cells["A1:A5"].Style.Border.Right.Style = ExcelBorderStyle.Thick;
                stranka.Cells["A5"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                stranka.Cells[1, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                Car Skoda = new Car();
                Skoda.Znacka = "Škoda";
                Skoda.SPZ = "BAC15973";
                Skoda.Cena = 40000;
                Skoda.NajeteKM = 9458;

                this.AddCar(Skoda);

                int IDAuta = 0; 
                foreach (Car auto in Cars)
                {
                    stranka.Cells[1, IDAuta + 2].Value = IDAuta;
                    stranka.Cells[2, IDAuta + 2].Value = auto.Znacka;
                    stranka.Cells[3, IDAuta + 2].Value = auto.SPZ;
                    stranka.Cells[4, IDAuta + 2].Value = auto.Cena;
                    stranka.Cells[5, IDAuta + 2].Value = auto.NajeteKM;

                    stranka.Cells[1, IDAuta + 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    stranka.Cells[5, IDAuta + 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                    IDAuta++;
                }
                //var newExel.SaveAs(new FileInfo(@"D:\novakja16\Github\evidence uzivatelu\Cars.xlsx");

                // NORMAND
                newExel.SaveAs(new FileInfo(@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\evidence uzivatelu\Cars.xlsx"));

                // EMIL
                
            }
        }
    }
}
