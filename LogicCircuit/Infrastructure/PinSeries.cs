using System.Collections.Generic;

namespace LogicCircuit.Infrastructure
{
    public class PinSeries
    {
        private readonly Pin[] pins;

        public readonly int Length;

        public PinSeries(params Pin[] pins)
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
