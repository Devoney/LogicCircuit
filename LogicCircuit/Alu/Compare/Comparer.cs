using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class Comparer
    {
        private readonly LessThan lessThan = new LessThan();
        private readonly GreaterThan greaterThan = new GreaterThan();
        private readonly XNOR equalsTo = new XNOR();

        public InputPin InputA { get { return lessThan.InputA; } }
        public InputPin InputB { get { return lessThan.InputB; } }

        public OutputPin IsLessThan { get { return lessThan.Output; } }
        public OutputPin IsGreaterThan { get { return greaterThan.Output; } }
        public OutputPin IsEqualTo { get { return equalsTo.Output; } }

        public Comparer()
        {
            greaterThan.InputA.ConnectTo(lessThan.InputA);
            greaterThan.InputB.ConnectTo(lessThan.InputB);

            equalsTo.InputA.ConnectTo(lessThan.InputA);
            equalsTo.InputB.ConnectTo(lessThan.InputB);
        }
    }
}
