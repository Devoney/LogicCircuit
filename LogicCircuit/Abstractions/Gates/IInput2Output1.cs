using LogicCircuit.Infrastructure;

namespace LogicCircuit.Abstractions.Gates
{
    public interface IInput2Output1
    {
        InputPin InputA { get; }
        InputPin InputB { get; }
        OutputPin Output { get; }
    }
}
