using Pokus_State_Machine.Abstracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokus_State_Machine
{
    class Die : AState
    {
        public Die()
        {
            Console.WriteLine("Have died");
        }

        public override void Do()
        {
            IsDone = false;
            Console.WriteLine("Deing");
            IsDone = true;
        }

        public override AState NextState(Agent agent)
        {
            agent.HP = 0;
            return null;
        }
    }
}
