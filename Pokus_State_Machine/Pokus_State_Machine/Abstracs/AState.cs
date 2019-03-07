using System;
using System.Collections.Generic;
using System.Text;

namespace Pokus_State_Machine.Abstracs
{
    public abstract class AState
    {
        public string Name_state;
        public  bool IsDone = false;

        public abstract AState NextState(Agent agent);

        public abstract void Do();



    }
}
