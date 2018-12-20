using LogicCircuit.Infrastructure;
using System;

namespace LogicCircuit.Abstractions.Gates.Simple
{
    public abstract class Gate
    {
        public string Name { get; set; }
        public OutputPin Output { get; protected set; }

        public Gate(string name = null)
        {
            Name = name;
            Output = new OutputPin(this, Operation);
        }
        
        protected abstract bool Operation();

        protected void OnInputChanged(object sender, EventArgs e)
        {
            Output.SetState();
        }

        public static implicit operator bool(Gate gate)
        {
            return gate.Output.State;
        }
    }
}
