using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kočka_a_myš
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            // creation of Meudam
            Cat cat = new Cat();

            // creation of Sqeek
            List<Mouse> mice = new List<Mouse>();
            mice.Add(new Mouse());

            bool hrajede = true;
            

            // game going
            while (hrajede)
            {   
                // is cat dead?
                if (!cat.Alive)
                {
                    // then crating a new cat!
                    int nahodnyag = rnd.Next(1, 21);
                    int nahodnycon = rnd.Next(1, 21);
                    Cat catnew = new Cat()
                    {

                        Agility = nahodnyag,
                        Health = nahodnycon

                    };
                }
                // is any mouse alive?
                bool anymousealive = false;
                // check every mouse
                foreach ( Mouse mouse in mice)
                {
                    // if is that mouse alive, tell that some mouse is alive
                    if (mouse.Alive)
                    {
                        anymousealive = true;
                    }
                }
                // is every mouse dead?
                if (!anymousealive)
                {
                    int numberofnewmice = rnd.Next(1, 6);
                    // create new set of mice!
                    for (int mouse = 0; mouse < numberofnewmice; mouse++)
                    {
                        int nahodnyag = rnd.Next(1, 21);
                        mice.Add(new Mouse()
                        {
                            Agility = nahodnyag
                        });
                    }
                }
                // calculation of chance for catch
                int chanceforcat = cat.CalculateChance();
                Console.WriteLine(chanceforcat);
                Console.ReadLine();

                // try to catch every mouse
                int numberofmice = 0;
                foreach (Mouse mouse in mice)
                {
                    bool hunt = true;
                    while (hunt)
                    {
                            // moment of suprise
                            if (numberofmice == 0)
                        {
                            chanceforcat = chanceforcat + 2;
                        } else
                        {
                            chanceforcat = chanceforcat - 2 * numberofmice;
                        }
                        // if mouse is alive
                        if(mouse.Alive)
                        {
                            numberofmice++;
                            int chanceformouse = mouse.CalculateChance();
                            Console.WriteLine(chanceforcat);
                            Console.ReadLine();
                            if (chanceformouse > chanceforcat)
                            {
                                cat.Health--;
                            } else if(chanceformouse < chanceforcat)
                            {
                                mouse.Alive = false;
                            }

                        } else
                        {
                            hunt = false;
                        }
                    }
                }
            }       
        }
    }
}
