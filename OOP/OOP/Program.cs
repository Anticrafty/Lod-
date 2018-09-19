using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Leg> legs = new List<Leg>();

            Leg leg1 = new Leg();
            leg1.Driving = true;
            leg1.Color = "red";

            legs.Add(leg1);

            Chair chair = new Chair();
            chair.legs = legs;

            Leg leg2 = new Leg();
            leg2.Driving = true;
            leg2.Color = "orange";

            legs.Add(leg2);

            Leg leg3 = new Leg();
            leg3.Driving = true;
            leg3.Color = "yelow";

            legs.Add(leg3);

            Leg leg4 = new Leg();
            leg4.Driving = false;
            leg4.Color = "green";

            legs.Add(leg4);

            Leg leg5 = new Leg();
            leg5.Driving = true;
            leg5.Color = "blue";

            legs.Add(leg5);


            legs.Add(new Leg()
            {
                Driving = true,
                Color = "purple"
            });

            foreach (Leg leg in chair.legs)
            {
                Console.WriteLine(leg.Color);
            }
            chair.ShowHealth();
        }
    }
}
