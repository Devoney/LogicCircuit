using LogicCircuit.Infrastructure;
using System;

namespace LogicCircuit.Abstractions.Gates.Simple
{
    public abstract class Gate
    {
        public string Name { get; set; }
        public Pin Output { get; protected set; }

        public Gate(bool initialOutputState, string name = null)
        {
            Name = name;
            Output = new Pin(this, true, initialOutputState,  "Output"); //BUG: It is actually an Ouput, but cannot be set...
        }

        public Gate(string name = null)
            :this(false, name)
        {
            
        }

        protected abstract bool Operation();

        protected void OnInputChanged(object sender, EventArgs e)
        {
            var newState = Operation();
            if (newState != Output.State)
            {
                Console.WriteLine(Name + ": " + newState);
                Output.State = newState;
            }
        }

        public static implicit operator bool(Gate gate)
        {
            return gate.Output.State;
        }
    }
}
