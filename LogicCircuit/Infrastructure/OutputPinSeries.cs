using LogicCircuit.Abstractions.Infrastructure;

namespace LogicCircuit.Infrastructure
{
    public class OutputPinSeries : IReadablePinSeries
    {
        private readonly IOutputPin[] pins;

        public int Length { get; private set; }

        public OutputPinSeries(params IOutputPin[] pins)
        {
            this.pins = pins;
            Length = pins.Length;
        }

        public bool this[int index]
        {
            get { return pins[index].State; }
        }
    }
}
