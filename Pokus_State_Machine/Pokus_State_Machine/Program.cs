using Pokus_State_Machine.Agents;
using Pokus_State_Machine.States;
using System;

namespace Pokus_State_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Guard hunter = new Guard();

            hunter.CurrentState = new Sentry();

            while (hunter.HP !=0 )
            {
                hunter.CurrentState.Do();
                hunter.CurrentState =  hunter.CurrentState.NextState(hunter);

            }
            Console.ReadLine();
        }
    }
}
