using LogicCircuit.Abstractions.Gates;
using LogicCircuit.Gates.Simple;
using LogicCircuit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Gates.Composite
{
    public class XNOR : IInput2Output1
    {
        private readonly XOR xor = new XOR();
        private readonly NOT not = new NOT();

        public Pin InputA => xor.InputA;
        public Pin InputB => xor.InputB;
        public Pin Output => not.Output;
        
        public XNOR()
        {
            xor.Output.ConnectTo(not.InputA);
        }
    }
}
