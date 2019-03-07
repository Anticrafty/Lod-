using System;
using System.Collections.Generic;
using System.Text;

namespace Pokus_State_Machine.Abstracs
{
    public abstract class Agent
    {        
        public string name_agent;
        public int HP;
        public AState CurrentState;

        //public StateMachine sm;
    }
}
