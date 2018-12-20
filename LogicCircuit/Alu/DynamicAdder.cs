using LogicCircuit.Alu;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu
{
    /// <summary>
    /// This class creates its circuits depending on constructor arguments.
    /// It is here to provide flexibility when playing around with different N-bit adders.
    /// To not have a concrete instance for each N-bit adder desired.
    /// For a correctly simulated circuit of an adder, see the Adder8Bit which is a 8-bit adder.
    /// </summary>
    public class DynamicAdder
    {
        private readonly FullAdder[] fullAdders;

        public InputPinSeries InputA { get; private set; }
        public InputPinSeries InputB { get; private set; }

        public OutputPinSeries Sum { get; private set; }
        public OutputPin Overflow { get; private set; }

        public DynamicAdder(int bits)
        {
            fullAdders = new FullAdder[bits];
            var inputPinSeriesA = new InputPin[bits];
            var inputPinSeriesB = new InputPin[bits];
            var outputPinSeriesSum = new OutputPin[bits];

            FullAdder previousFullAdder = null;
            for (var i=0; i<bits; i++)
            {
                var fullAdder = new FullAdder();

                if (previousFullAdder != null)
                {
                    previousFullAdder.CarryOver.ConnectTo(fullAdder.CarryIn);
                }

                fullAdders[i] = fullAdder;
                inputPinSeriesA[i] = fullAdder.InputA;
                inputPinSeriesB[i] = fullAdder.InputB;
                outputPinSeriesSum[i] = fullAdder.Sum;

                previousFullAdder = fullAdder;
            }

            Overflow = previousFullAdder.CarryOver;

            InputA = new InputPinSeries(inputPinSeriesA);
            InputB = new InputPinSeries(inputPinSeriesB);
            Sum = new OutputPinSeries(outputPinSeriesSum);
        }
    }
}
