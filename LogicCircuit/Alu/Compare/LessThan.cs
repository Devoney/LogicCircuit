using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class LessThan
    {
        private readonly NOT not = new NOT();
        private readonly AND and = new AND();

        public InputPin InputA {  get { return not.InputA; } }
        public InputPin inputB {  get { return and.InputB; } }

        public OutputPin Output { get { return and.Output; } }

        public LessThan()
        {
            not.Output.ConnectTo(and.InputA);
        }
    }
}
