using LogicCircuit.Infrastructure;

namespace LogicCircuit.Abstractions.Gates.Simple
{
    public abstract class Gate2Input : Gate1Input, IInput2Output1
    {
        public Pin InputB { get; protected set; }

        protected Gate2Input(string name = null)
            : base(name)
        {
            InputB = new Pin(this, "InputB");
            InputB.StateChanged += OnInputChanged;
            InputB.Connected += OnInputChanged;
        }

        public void SetInputB(bool value)
        {
            InputB.State = value;
        }
    }
}
