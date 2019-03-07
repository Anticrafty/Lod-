using Pokus_State_Machine.Abstracs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Pokus_State_Machine.States
{
    public class Sentry: AState
    {
        Random rnd = new Random();

        public Sentry()
        {
            Name_state = "sentry";
        }

        public override void Do()
        {
            IsDone = false;
            Console.WriteLine("Sentring");
            IsDone = true;
        }        

        public override AState NextState(Agent agent)
        {
            if (rnd.Next(1, 3) == 2)
            {
                return new Attack();
            }
            return new Sentry();
        }
    }
}
