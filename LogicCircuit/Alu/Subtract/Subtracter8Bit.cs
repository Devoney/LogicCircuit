using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Subtract
{
    public class Subtracter8Bit
    {
        private readonly FullSubtracter fullSubtracter1 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter2 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter3 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter4 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter5 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter6 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter7 = new FullSubtracter();
        private readonly FullSubtracter fullSubtracter8 = new FullSubtracter();

        public InputPinSeries InputA { get; private set; }
        public InputPinSeries InputB { get; private set; }
        public OutputPinSeries Sub { get; private set; }
        public OutputPin Overflow { get; private set; }

        public Subtracter8Bit()
        {
            InputA = new InputPinSeries(fullSubtracter1.InputA, fullSubtracter2.InputA, fullSubtracter3.InputA, fullSubtracter4.InputA,
                fullSubtracter5.InputA, fullSubtracter6.InputA, fullSubtracter7.InputA, fullSubtracter8.InputA);

            InputB = new InputPinSeries(fullSubtracter1.InputB, fullSubtracter2.InputB, fullSubtracter3.InputB, fullSubtracter4.InputB,
                fullSubtracter5.InputB, fullSubtracter6.InputB, fullSubtracter7.InputB, fullSubtracter8.InputB);

            Sub = new OutputPinSeries(fullSubtracter1.Sub, fullSubtracter2.Sub, fullSubtracter3.Sub, fullSubtracter4.Sub,
                fullSubtracter5.Sub, fullSubtracter6.Sub, fullSubtracter7.Sub, fullSubtracter8.Sub);

            fullSubtracter1.CarryOver.ConnectTo(fullSubtracter2.CarryIn);
            fullSubtracter2.CarryOver.ConnectTo(fullSubtracter3.CarryIn);
            fullSubtracter3.CarryOver.ConnectTo(fullSubtracter4.CarryIn);
            fullSubtracter4.CarryOver.ConnectTo(fullSubtracter5.CarryIn);
            fullSubtracter5.CarryOver.ConnectTo(fullSubtracter6.CarryIn);
            fullSubtracter6.CarryOver.ConnectTo(fullSubtracter7.CarryIn);
            fullSubtracter7.CarryOver.ConnectTo(fullSubtracter8.CarryIn);

            Overflow = fullSubtracter8.CarryOver;
        }
    }
}
