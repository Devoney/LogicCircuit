using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Gates.Composite
{
    public class NOR : IInput2Output1
    {
        private readonly OR or = new OR();
        private readonly NOT not = new NOT();

        public InputPin InputA => or.InputA;
        public InputPin InputB => or.InputB;
        public OutputPin Output => not.Output;

        public NOR()
        {
            or.Output.ConnectTo(not.InputA);
        }
    }
}
