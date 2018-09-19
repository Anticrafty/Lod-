using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Chair
    {

        public string Color;

        public int Height;

        public List<Leg> legs = new List<Leg>();

        private int health = 100;

        public bool IsBroken = false;
        public void TakeDamage()
        {
            health--;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
        }
        public void ShowHealth()
        {
            Console.WriteLine(health);
        }
        public void IsReallyBroken()
        {
            if (health == 0)
            {
                IsBroken = true;
            }
        }
}
