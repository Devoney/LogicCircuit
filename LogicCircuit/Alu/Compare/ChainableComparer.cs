using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class ChainableComparer
    {
        private readonly Comparer comparer = new Comparer();
        private readonly AND andIsLessThan = new AND();
        private readonly AND andIsEqualTo = new AND();
        private readonly AND andIsGreaterThan = new AND();
        private readonly OR orIsLessThan = new OR();
        private readonly OR orIsEqualTo = new OR();
        private readonly OR orIsGreaterThan = new OR();
        private readonly NOT not = new NOT();

        public InputPin IsOff { get { return not.InputA; } }

        public InputPin InputA { get { return comparer.InputA; } }
        public InputPin InputB { get { return comparer.InputB; } }

        public InputPin IsLessThanInput {  get { return orIsLessThan.InputA; } }
        public InputPin IsEqualToInput { get { return orIsEqualTo.InputA; } }
        public InputPin IsGreaterThanInput { get { return orIsGreaterThan.InputA; } }

        public OutputPin IsLessThanOutput { get { return orIsLessThan.Output; } }
        public OutputPin IsEqualToOutput { get { return orIsEqualTo.Output; } }
        public OutputPin IsGreaterThanOutput { get { return orIsGreaterThan.Output; } }

        public ChainableComparer()
        {
            andIsLessThan.InputA.ConnectTo(not.Output);
            andIsEqualTo.InputA.ConnectTo(not.Output);
            andIsGreaterThan.InputA.ConnectTo(not.Output);

            andIsLessThan.Output.ConnectTo(orIsLessThan.InputB);
            andIsEqualTo.Output.ConnectTo(orIsEqualTo.InputB);
            andIsGreaterThan.Output.ConnectTo(orIsGreaterThan.InputB);

            comparer.IsLessThan.ConnectTo(andIsLessThan.InputB);
            comparer.IsEqualTo.ConnectTo(andIsEqualTo.InputB);
            comparer.IsGreaterThan.ConnectTo(andIsGreaterThan.InputB);
        }
    }
}
