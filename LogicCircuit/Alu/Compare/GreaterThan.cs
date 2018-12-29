using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class GreaterThan
    {
        private readonly NOT not = new NOT();
        private readonly AND and = new AND();

        public InputPin InputA {  get { return and.InputB; } }
        public InputPin InputB {  get { return not.InputA; } }

        public OutputPin Output {  get { return and.Output; } }

        public GreaterThan()
        {
            not.Output.ConnectTo(and.InputA);
        }
    }
}
