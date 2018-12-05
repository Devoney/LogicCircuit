using LogicCircuit.Infrastructure;
using System;

namespace LogicCircuit.Abstractions.Gates.Simple
{
    public abstract class Gate
    {
        public string Name { get; set; }
        public Pin Output { get; protected set; }

        public Gate(string name = null)
        {
            Name = name;
            Output = new Pin(this, "Output");
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
