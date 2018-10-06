using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Lod
    {
        public List<Policko> Kostra = new List<Policko>();
        public bool Stav;

        public static List<Policko> Vypocitejlod(int odpoved, List<int> pozice)
        {
            int konecX = 0;
            int konecY = 0;
            List<int> xs = new List<int>();
            List<int> ys = new List<int>();
            List<Policko> buck = new List<Policko>();
            int odpovedi = odpoved - 1; //3-1=2
            int x = pozice[0]; //5
            int y = pozice[1]; //5
            int rotace = pozice[2]; // 1
            if (odpoved > 0 && odpoved < 7)
            {
                if (odpoved > 0 && odpoved < 6)
                {
                    if (rotace == 1) // <
                    {
                        // nahoru
                        konecY = y - odpovedi; // 3
                        konecX = x; //5
                    }
                    else if (rotace == 2)
                    {
                        // doprava
                        konecX = x + odpovedi;
                        konecY = y;
                    }
                    else if (rotace == 3)
                    {
                        // dolu
                        konecY = y + odpovedi;
                        konecX = x;
                    }
                    else
                    {
                        // doleva
                        konecX = x - odpovedi;
                        konecY = y;
                    }
                }
                else
                {
                    if (rotace == 1) 
                    {
                        // nahoru
                        konecY = y - 2; 
                        konecX = x + 1; 
                    }
                    else if (rotace == 2)
                    {
                        // doprava
                        konecX = x + 2;
                        konecY = y + 1;
                    }
                    else if (rotace == 3)
                    {
                        // dolu
                        konecY = y + 2;
                        konecX = x - 1;
                    }
                    else
                    {
                        // doleva
                        konecX = x - 2;
                        konecY = y - 1;
                    }
                }
                if (konecY > 0 && konecY < 10 && konecX > 0 && konecX < 10)
                {
                    // pokud je začatek větší než konec musí to začít koncem a končit začátkem
                    //x
                    int konecXs = 0;
                    int zacatekX = 0;
                    if (x > konecX)
                    {
                        zacatekX = konecX;
                        konecXs = x;
                    } else
                    {
                        zacatekX = x; //5
                        konecXs = konecX; //5
                    }
                    //y
                    int konecYs = 0;
                    int zacatekY = 0;
                    if (y > konecY)
                    {
                        zacatekY = konecY; //3
                        konecYs = y; //5
                    }
                    else
                    {
                        zacatekY = y;
                        konecYs = konecY;
                    }
                    for (; zacatekY < konecYs + 1; zacatekY++)// 3 < 6=5+1 
                    {

                        for (int zacatekXs = zacatekX; zacatekXs < konecXs + 1; zacatekXs++) // 5 < 6=5+1 / 3×5,4×5,5×5
                        {
                            buck.Add(new Policko
                            {
                                X = zacatekXs,
                                Y = zacatekY,
                                Stav = 1
                            });

                        }
                    }
                }
                else
                {
                    buck.Add(new Policko
                    {
                        X = 0,
                        Y = 0,
                        Stav = 0
                    });
                }
               }
            if (odpoved == 7)
            {
                int pivotX = 0;
                int pivotY = 0;
                //-------------
                int O1X = 0;
                int O1Y = 0;
                int O2X = 0;
                int O2Y = 0;
                //nahoru
                if (rotace == 1)
                {
                    pivotX = 1;
                    pivotY = 3;
                    //-------------
                     O1X =2;
                     O1Y =2;
                     O2X =1;
                     O2Y =1;
                }
                else if (rotace == 2)
                {
                    // doprava
                     pivotX = 1;
                     pivotY = 1;
                    //-------------
                     O1X =2;
                     O1Y =2;
                     O2X =3;
                     O2Y =1;
                }
                else if (rotace == 3)
                {
                    // dolu
                     pivotX = 2;
                     pivotY = 1;
                    //-------------
                     O1X =1;
                     O1Y =2;
                     O2X =2;
                     O2Y =3;
                }
                else
                {
                    // doleva
                     pivotX = 3;
                     pivotY = 2;
                    //-------------
                     O1X =2;
                     O1Y =1;
                     O2X =1;
                     O2Y =2;
                }
                int posunX = x - pivotX;
                int posunY = y - pivotY;
                int O1XZ = O1X + posunX;
                int O1YZ = O1Y + posunY;
                int O2XZ = O2X + posunX; 
                int O2YZ = O2Y + posunY; 
                if (O1XZ < 10 && O1XZ > 0 && O1YZ < 10 && O1YZ > 0 && O2XZ < 10 && O2XZ > 0 && O2YZ < 10 && O2YZ > 0 )
                {
                    buck.Add(new Policko
                    {
                        X = x,
                        Y = y,
                        Stav = 0
                    });
                    buck.Add(new Policko
                    {
                        X = O1XZ,
                        Y = O1YZ,
                        Stav = 0
                    });
                    buck.Add(new Policko
                    {
                        X = O2XZ,
                        Y = O2YZ,
                        Stav = 0
                    });
                }
                else
                {
                    buck.Add(new Policko
                    {
                        X = 0,
                        Y = 0,
                        Stav = 0
                    });
                }
            }
            if (odpoved == 8)
            {
                int pivotX = 0;
                int pivotY = 0;
                //-------------
                int O1X = 0;
                int O1Y = 0;
                int O2X = 0;
                int O2Y = 0;
                int O3X = 0;
                int O3Y = 0;
                //nahoru
                if (rotace == 1)
                {
                    pivotX = 1;
                    pivotY = 3;
                    //-------------
                    O1X = 2;
                    O1Y = 2;
                    O2X = 1;
                    O2Y = 1;
                    O3X = 1;
                    O3Y = 2;
                }
                else if (rotace == 2)
                {
                    // doprava
                    pivotX = 1;
                    pivotY = 1;
                    //-------------
                    O1X = 2;
                    O1Y = 2;
                    O2X = 3;
                    O2Y = 1;
                    O3X = 2;
                    O3Y = 1;
                }
                else if (rotace == 3)
                {
                    // dolu
                    pivotX = 2;
                    pivotY = 1;
                    //-------------
                    O1X = 1;
                    O1Y = 2;
                    O2X = 2;
                    O2Y = 3;
                    O3X = 2;
                    O3Y = 2;
                }
                else
                {
                    // doleva
                    pivotX = 3;
                    pivotY = 2;
                    //-------------
                    O1X = 2;
                    O1Y = 1;
                    O2X = 1;
                    O2Y = 2;
                    O3X = 2;
                    O3Y = 2;
                }
                int posunX = x - pivotX;
                int posunY = y - pivotY;
                int O1XZ = O1X + posunX;
                int O1YZ = O1Y + posunY;
                int O2XZ = O2X + posunX;
                int O2YZ = O2Y + posunY;
                int O3XZ = O3X + posunX;
                int O3YZ = O3Y + posunY;
                if (O1XZ < 10 && O1XZ > 0 && O1YZ < 10 && O1YZ > 0 && O2XZ < 10 && O2XZ > 0 && O2YZ < 10 && O2YZ > 0 && O3XZ < 10 && O3XZ > 0 && O3YZ < 10 && O3YZ > 0)
                {
                    buck.Add(new Policko
                    {
                        X = x,
                        Y = y,
                        Stav = 0
                    });
                    buck.Add(new Policko
                    {
                        X = O1XZ,
                        Y = O1YZ,
                        Stav = 0
                    });
                    buck.Add(new Policko
                    {
                        X = O2XZ,
                        Y = O2YZ,
                        Stav = 0
                    });
                    buck.Add(new Policko
                    {
                        X = O3XZ,
                        Y = O3YZ,
                        Stav = 0
                    });
                }
                else
                {
                    buck.Add(new Policko
                    {
                        X = 0,
                        Y = 0,
                        Stav = 0
                    });
                }
            }
            if (odpoved == 9)
            {
                if (x > 1 && x < 9)
                {
                    int zacatekXA = x - 1;
                    int konecXA = x + 1;
                    int zacatekYA = y;
                    int konecYA = y;

                    for (; zacatekYA < konecYA + 1; zacatekYA++)// 3 < 6=5+1 
                    {
                        Console.WriteLine("mlemA1");
                        for (int zacatekXAs = zacatekXA; zacatekXAs < konecXA + 1; zacatekXAs++) 
                        {
                            Console.WriteLine("mlemA2");
                            buck.Add(new Policko
                            {
                                X = zacatekXAs,
                                Y = zacatekYA,
                                Stav = 1
                            });

                        }
                    }

                    int zacatekYB = x - 1;
                    int konecYB = x + 1;
                    int zacatekXB = y;
                    int konecXB = y;
                    for (; zacatekYB < konecYB + 1; zacatekYB++)
                    {
                        Console.WriteLine("mlemB1");
                        for (int zacatekXBs = zacatekXB; zacatekXBs < konecXB + 1; zacatekXBs++) 
                        {
                            Console.WriteLine("mlemB");
                            if (zacatekXBs != x || zacatekYB != y)
                            {
                                buck.Add(new Policko
                                {
                                    X = zacatekXBs,
                                    Y = zacatekYB,
                                    Stav = 1
                                });
                            }
                        }
                    }    
                }
                else
                {
                    buck.Add(new Policko
                    {
                        X = 0,
                        Y = 0,
                        Stav = 0
                    });
                }
            }
            return buck;
        }
    }
}
