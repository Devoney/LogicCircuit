using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu
{
    public class HalfAdder
    {
        private readonly XOR xor = new XOR();
        private readonly AND and = new AND();

        public Pin InputA { get { return xor.InputA; } }
        public Pin InputB { get { return xor.InputB; } }
        
        public Pin Sum { get { return xor.Output; } }
        public Pin CarryOver { get { return and.Output; } }

        public HalfAdder()
        {
            and.InputA.ConnectTo(xor.InputA);
            and.InputB.ConnectTo(xor.InputB);
        }
    }
}
