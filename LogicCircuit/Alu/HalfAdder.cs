using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu
{
    public class HalfAdder
    {
        private readonly XOR xor = new XOR();
        private readonly AND and = new AND();

        public InputPin InputA { get { return xor.InputA; } }
        public InputPin InputB { get { return xor.InputB; } }
        
        public OutputPin Sum { get { return xor.Output; } }
        public OutputPin CarryOver { get { return and.Output; } }

        public HalfAdder()
        {
            and.InputA.ConnectTo(xor.InputA);
            and.InputB.ConnectTo(xor.InputB);
        }
    }
}
