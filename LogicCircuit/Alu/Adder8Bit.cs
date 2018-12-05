using LogicCircuit.Abstractions.ALU;

namespace LogicCircuit.Alu
{
    /// <summary>
    /// Use the AdderFactory to construct an Adder
    /// </summary>
    public class Adder8Bit : AdderBase
    {
        public Adder8Bit() : base(8)
        {
        }
    }
}
