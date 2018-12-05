using LogicCircuit.Abstractions.Infrastructure;

namespace LogicCircuit.Infrastructure
{
    public class PinSeries
    {
        private readonly IPin[] pins;

        public readonly int Length;

        public PinSeries(params IPin[] pins)
        {
            this.pins = pins;
            Length = pins.Length;
        }

        public bool this[int index]
        {
            get { return pins[index].State; }
            set { pins[index].State = value; }
        }
    }
}
