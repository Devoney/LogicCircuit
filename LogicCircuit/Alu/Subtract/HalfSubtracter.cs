using LogicCircuit.Gates.Composite;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Alu.Subtract
{
    public class HalfSubtracter
    {
        private readonly NOT not = new NOT();
        private readonly AND and = new AND();
        private readonly XOR xor = new XOR();

        public Pin InputA { get { return not.InputA; } }
        public Pin InputB { get { return xor.InputB; } }

        public Pin CarryOver { get { return and.Output; } }
        public Pin Sub { get { return xor.Output; } }

        public HalfSubtracter()
        {
            not.Output.ConnectTo(and.InputA);
            xor.InputA.ConnectTo(InputA);
            xor.Output.ConnectTo(and.InputB);
        }
    }
}
