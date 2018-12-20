namespace LogicCircuit.Abstractions.Infrastructure
{
    public interface IReadablePinSeries
    {
        bool this[int index] { get; }
        int Length { get; }
    }
}
