using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Hokus_Pokus_Launcher
{
    class sln
    {
        public string csproject_Location;
        public string exe_location;
        public string README_location;

        /*public void get_exe_location()
        {
            XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";
            XDocument projDefinition = XDocument.Load(csproject_Location);
            

            IEnumerable<string> references = projDefinition
            .Element(msbuild + "Project")
            .Elements(msbuild + "ItemGroup")
            .Elements(msbuild + "Reference")
            .Select(refElem => refElem.Value);
            foreach (string reference in references)
            {
               string test = reference;
            }
        }*/
    }
}
