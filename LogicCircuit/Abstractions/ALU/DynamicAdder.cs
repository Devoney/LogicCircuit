using LogicCircuit.Alu;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Abstractions.ALU
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

        public PinSeries InputA { get; private set; }
        public PinSeries InputB { get; private set; }

        public PinSeries Sum { get; private set; }
        public Pin Overflow { get; private set; }

        public DynamicAdder(int bits)
        {
            fullAdders = new FullAdder[bits];
            var inputPinSeriesA = new Pin[bits];
            var inputPinSeriesB = new Pin[bits];
            var outputPinSeriesSum = new Pin[bits];

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

            InputA = new PinSeries(inputPinSeriesA);
            InputB = new PinSeries(inputPinSeriesB);
            Sum = new PinSeries(outputPinSeriesSum);
        }
    }
}
