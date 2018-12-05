using LogicCircuit.Alu;
using System.Collections.Generic;

namespace LogicCircuit.Abstractions.ALU
{
    public abstract class AdderBase
    {
        private readonly FullAdder[] fullAdders;

        public PinSeries InputA { get; set; }
        public PinSeries InputB { get; set; }

        public PinSeries Sum { get; set; }

        protected AdderBase(int bits)
        {
            fullAdders = new FullAdder[bits];
            var inputPinSeriesA = new Pin[bits];
            var inputPinSeriesB = new Pin[bits];
            var outputPinSeriesSum = new Pin[bits];

            FullAdder previousFullAdder = null;
            for (var i=bits-1; i >= 0; i--)
            {
                var fullAdder = new FullAdder();

                if (previousFullAdder != null)
                {
                    fullAdder.CarryOver.ConnectTo(previousFullAdder.CarryIn);
                }

                fullAdders[i] = fullAdder;
                inputPinSeriesA[i] = fullAdder.InputA;
                inputPinSeriesB[i] = fullAdder.InputB;
                outputPinSeriesSum[bits-1-i] = fullAdder.Sum;

                previousFullAdder = fullAdder;
            }

            InputA = new PinSeries(inputPinSeriesA);
            InputB = new PinSeries(inputPinSeriesB);
            Sum = new PinSeries(outputPinSeriesSum);
        }
    }
}
