using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Add
{
    public class Adder8Bit
    {
        private readonly FullAdder fullAdder1 = new FullAdder();
        private readonly FullAdder fullAdder2 = new FullAdder();
        private readonly FullAdder fullAdder3 = new FullAdder();
        private readonly FullAdder fullAdder4 = new FullAdder();
        private readonly FullAdder fullAdder5 = new FullAdder();
        private readonly FullAdder fullAdder6 = new FullAdder();
        private readonly FullAdder fullAdder7 = new FullAdder();
        private readonly FullAdder fullAdder8 = new FullAdder();

        public InputPinSeries InputA { get; private set; }
        public InputPinSeries InputB { get; private set; }
        public OutputPinSeries Sum { get; private set; }
        public OutputPin Overflow { get; private set; }

        public Adder8Bit()
        {
            InputA = new InputPinSeries(fullAdder1.InputA, fullAdder2.InputA, fullAdder3.InputA, fullAdder4.InputA,
                fullAdder5.InputA, fullAdder6.InputA, fullAdder7.InputA, fullAdder8.InputA);

            InputB = new InputPinSeries(fullAdder1.InputB, fullAdder2.InputB, fullAdder3.InputB, fullAdder4.InputB,
                fullAdder5.InputB, fullAdder6.InputB, fullAdder7.InputB, fullAdder8.InputB);

            Sum = new OutputPinSeries(fullAdder1.Sum, fullAdder2.Sum, fullAdder3.Sum, fullAdder4.Sum,
                fullAdder5.Sum, fullAdder6.Sum, fullAdder7.Sum, fullAdder8.Sum);

            fullAdder1.CarryOver.ConnectTo(fullAdder2.CarryIn);
            fullAdder2.CarryOver.ConnectTo(fullAdder3.CarryIn);
            fullAdder3.CarryOver.ConnectTo(fullAdder4.CarryIn);
            fullAdder4.CarryOver.ConnectTo(fullAdder5.CarryIn);
            fullAdder5.CarryOver.ConnectTo(fullAdder6.CarryIn);
            fullAdder6.CarryOver.ConnectTo(fullAdder7.CarryIn);
            fullAdder7.CarryOver.ConnectTo(fullAdder8.CarryIn);

            Overflow = fullAdder8.CarryOver;
        }
    }
}
