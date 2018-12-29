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
        private readonly OR orIsGreaterThan = new OR();

        //TODO: Having two NOT gates to be able to have an IsOn input (instead of IsOff) makes little sense.
        private readonly NOT not1 = new NOT();
        private readonly NOT not2 = new NOT();

        public InputPin IsOn { get { return not1.InputA; } }

        public InputPin InputA { get { return comparer.InputA; } }
        public InputPin InputB { get { return comparer.InputB; } }

        public InputPin IsLessThanInput {  get { return orIsLessThan.InputA; } }
        public InputPin IsGreaterThanInput { get { return orIsGreaterThan.InputA; } }

        public OutputPin IsLessThanOutput { get { return orIsLessThan.Output; } }
        public OutputPin IsEqualToOutput {  get { return andIsEqualTo.Output; } }
        public OutputPin IsGreaterThanOutput { get { return orIsGreaterThan.Output; } }

        public ChainableComparer()
        {
            not1.Output.ConnectTo(not2.InputA);

            andIsLessThan.InputA.ConnectTo(not2.Output);
            andIsEqualTo.InputA.ConnectTo(not2.Output);
            andIsGreaterThan.InputA.ConnectTo(not2.Output);

            andIsLessThan.Output.ConnectTo(orIsLessThan.InputB);
            andIsEqualTo.InputB.ConnectTo(comparer.IsEqualTo);
            andIsGreaterThan.Output.ConnectTo(orIsGreaterThan.InputB);

            comparer.IsLessThan.ConnectTo(andIsLessThan.InputB);
            comparer.IsGreaterThan.ConnectTo(andIsGreaterThan.InputB);
        }
    }
}
