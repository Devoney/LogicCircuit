namespace LogicCircuit.Abstractions.Infrastructure
{
    public interface IInputPin : IOutputPin
    {
        new bool State { get; set; }
    }
}