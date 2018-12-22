using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Subtract
{
    public class FullSubtracter
    {
        private readonly HalfSubtracter halfSubtracter1 = new HalfSubtracter();
        private readonly HalfSubtracter halfSubtracter2 = new HalfSubtracter();
        private readonly OR or = new OR();

        public InputPin InputA { get; private set; }
        public InputPin InputB { get; private set; }
        public InputPin CarryIn { get; private set; }

        public OutputPin CarryOver { get; private set; }
        public OutputPin Sub { get; private set; }

        public FullSubtracter()
        {
            InputA = halfSubtracter1.InputA;
            InputB = halfSubtracter1.InputB;
            halfSubtracter1.Sub.ConnectTo(halfSubtracter2.InputA);
            CarryIn = halfSubtracter2.InputB;
            or.InputA.ConnectTo(halfSubtracter1.CarryOver);
            or.InputB.ConnectTo(halfSubtracter2.CarryOver);
            CarryOver = or.Output;
            Sub = halfSubtracter2.Sub;
        }
    }
}
