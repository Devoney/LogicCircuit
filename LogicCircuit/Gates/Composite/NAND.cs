using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Gates.Composite
{
    public class NAND : IInput2Output1
    {
        private readonly AND and = new AND();
        private readonly NOT not = new NOT();

        public Pin InputA { get { return and.InputA; } }
        public Pin InputB { get { return and.InputB; } }
        public Pin Output { get { return not.Output; } }

        public NAND()
        {
            and.Output.ConnectTo(not.InputA);
        }
    }
}
