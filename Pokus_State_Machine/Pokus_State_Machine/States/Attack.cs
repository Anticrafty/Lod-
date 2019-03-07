using Pokus_State_Machine.Abstracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokus_State_Machine.States
{
    public class Attack : AState
    {
        Random rnd = new Random();
        public Attack()
        {
            Name_state = "Attack";
        }

        public override void Do()
        {
            IsDone = false;
            Console.WriteLine("Attaking");
            IsDone = true;
        }

        public override AState NextState(Agent agent)
        {
             int sance = rnd.Next(1, 4);
            if (sance == 1 )
            {
                return new Sentry();
            }
            else
            {
                return new Die();
            }
        }
    }
}
