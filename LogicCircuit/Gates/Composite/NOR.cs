using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Gates.Simple;

namespace LogicCircuit.Gates.Composite
{
    public class NOR : IInput2Output1
    {
        private readonly OR or = new OR();
        private readonly NOT not = new NOT();

        public Pin InputA => or.InputA;
        public Pin InputB => or.InputB;
        public Pin Output => not.Output;

        public NOR()
        {
            or.Output.ConnectTo(not.InputA);
        }
    }
}
