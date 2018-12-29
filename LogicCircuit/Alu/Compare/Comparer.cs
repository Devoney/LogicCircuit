using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class Comparer
    {
        private readonly InternalComparer internalComparer = new InternalComparer();
        private readonly AND andIsLessThan = new AND();
        private readonly AND andIsEqualTo = new AND();
        private readonly AND andIsGreaterThan = new AND();
        private readonly NOT not = new NOT();

        public InputPin IsOff {  get { return not.InputA; } }

        public InputPin InputA { get { return internalComparer.InputA; } }
        public InputPin InputB { get { return internalComparer.InputB; } }

        public OutputPin IsLessThan { get { return andIsLessThan.Output; } }
        public OutputPin IsGreaterThan { get { return andIsGreaterThan.Output; } }
        public OutputPin IsEqualTo { get { return andIsEqualTo.Output; } }

        public Comparer()
        {
            andIsLessThan.InputA.ConnectTo(not.Output);
            andIsEqualTo.InputA.ConnectTo(not.Output);
            andIsGreaterThan.InputA.ConnectTo(not.Output);

            internalComparer.IsLessThan.ConnectTo(andIsLessThan.InputB);
            internalComparer.IsEqualTo.ConnectTo(andIsEqualTo.InputB);
            internalComparer.IsGreaterThan.ConnectTo(andIsGreaterThan.InputB);
        }

        private class InternalComparer
        {
            private readonly LessThan lessThan = new LessThan();
            private readonly GreaterThan greaterThan = new GreaterThan();
            private readonly XNOR equalsTo = new XNOR();

            public InputPin InputA { get { return lessThan.InputA; } }
            public InputPin InputB { get { return lessThan.InputB; } }

            public OutputPin IsLessThan { get { return lessThan.Output; } }
            public OutputPin IsGreaterThan { get { return greaterThan.Output; } }
            public OutputPin IsEqualTo { get { return equalsTo.Output; } }

            public InternalComparer()
            {
                greaterThan.InputA.ConnectTo(lessThan.InputA);
                greaterThan.InputB.ConnectTo(lessThan.InputB);

                equalsTo.InputA.ConnectTo(lessThan.InputA);
                equalsTo.InputB.ConnectTo(lessThan.InputB);
            }
        }
    }
}
