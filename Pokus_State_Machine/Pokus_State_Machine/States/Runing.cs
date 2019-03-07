using Pokus_State_Machine.Abstracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokus_State_Machine.States
{
    public class Runing : AState
    {
        public Runing()
        {
            Name_state = "Runing";
        }

        public override void Do()
        {
            IsDone = false;
            Console.WriteLine("Runing");
            IsDone = true;
        }

        public override AState NextState(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
