using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Gates.Composite
{
    public class NAND : IInput2Output1
    {
        private readonly AND and = new AND();
        private readonly NOT not = new NOT();

        public InputPin InputA { get { return and.InputA; } }
        public InputPin InputB { get { return and.InputB; } }
        public OutputPin Output { get { return not.Output; } }

        public NAND()
        {
            and.Output.ConnectTo(not.InputA);
        }
    }
}
