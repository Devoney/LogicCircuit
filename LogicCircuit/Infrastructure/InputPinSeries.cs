using LogicCircuit.Abstractions.Infrastructure;

namespace LogicCircuit.Infrastructure
{
    public class InputPinSeries : IReadablePinSeries
    {
        private readonly IInputPin[] pins;

        public int Length { get; private set; }

        public InputPinSeries(params IInputPin[] pins)
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
