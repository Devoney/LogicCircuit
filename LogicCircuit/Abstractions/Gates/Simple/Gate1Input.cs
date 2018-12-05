using LogicCircuit.Infrastructure;

namespace LogicCircuit.Abstractions.Gates.Simple
{
    public abstract class Gate1Input : Gate
    {
        public Pin InputA { get; protected set; }

        protected Gate1Input(string name = null)
            : base(name)
        {
            InputA = new Pin(this, "InputA");
            InputA.StateChanged += OnInputChanged;
            InputA.Connected += OnInputChanged;
        }

        public void SetInputA(bool value)
        {
            InputA.State = value;
        }
    }
}
