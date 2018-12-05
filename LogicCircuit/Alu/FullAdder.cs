using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu
{
    public class FullAdder
    {
        private readonly HalfAdder halfAdder1 = new HalfAdder();
        private readonly HalfAdder halfAdder2 = new HalfAdder();
        private readonly OR or = new OR();

        public Pin InputA { get; private set; }
        public Pin InputB { get; private set; }
        public Pin CarryIn { get; private set; }

        public Pin CarryOver { get; private set; }
        public Pin Sum { get; private set; }

        public FullAdder()
        {
            InputA = halfAdder1.InputA;
            InputB = halfAdder1.InputB;
            halfAdder1.Sum.ConnectTo(halfAdder2.InputA);
            CarryIn = halfAdder2.InputB;
            or.InputA.ConnectTo(halfAdder1.CarryOver);
            or.InputB.ConnectTo(halfAdder2.CarryOver);
            CarryOver = or.Output;
            Sum = halfAdder2.Sum;
        }
    }
}
