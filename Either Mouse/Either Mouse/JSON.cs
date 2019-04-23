using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Either_Mouse
{
    public class JSON
    {

        public string Path;
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public JSON(string panther)
        {
            if (panther == null)
            {
                // Schollar 52017189            
                Path = @"D:\source\GitHub\Lod-\Either Mouse\zarizeni.json";
                // Norman

                // Emil
            }
            else
            {
                Path = panther;
            }

        }

        public void uloz_zarizeni(List<Zarizeni> zarizeni)
        {
            string data_zarizeni = JsonConvert.SerializeObject(zarizeni, settings);

            System.IO.File.WriteAllText(Path, data_zarizeni);
        }
        public List<Zarizeni> nacti_zarizeni()
        {
            if (File.Exists(Path))
            { 
                string UserFromFile = File.ReadAllText(Path);
                return JsonConvert.DeserializeObject<List<Zarizeni>>(UserFromFile, settings);
            }
            return new List<Zarizeni>();
        }

    }
}
