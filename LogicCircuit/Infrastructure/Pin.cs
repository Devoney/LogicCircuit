using LogicCircuit.Abstractions.Gates.Simple;
using System;

namespace LogicCircuit.Infrastructure
{
    public class Pin
    {
        public event EventHandler StateChanged;
        public event EventHandler Connected;

        public bool IsOutput { get; private set; }

        private bool _state;
        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                if (IsOutput) throw new InvalidOperationException("Can not set output pins.");
                if (_state != value)
                {
                    _state = value;
                    OnStateChanged();
                }
            }
        }

        private Junction _junction;

        public Gate Gate
        {
            get; private set;
        }

        public string Name { get; set; }

        public Pin(Gate gate, string name = null)
            :this(gate, false, name)
        {

        }

        public Pin(Gate gate, bool isOutput, string name = null)
        {
            IsOutput = isOutput;
            Name = name;
            Gate = gate;
        }

        public void ConnectTo(Pin pin)
        {
            if (pin._junction != null)
            {
                pin._junction.Add(this);
            }
            else
            {
                if (_junction == null)
                {
                    _junction = new Junction();
                }
                _junction.Add(this);
                _junction.Add(pin);
            }
        }

        private void OnStateChanged()
        {
            if (!string.IsNullOrEmpty(Gate.Name) && !string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Gate: " + Gate.Name + " - PIN: " + Name + " = " + State);
            }
            if (StateChanged == null) return;
            StateChanged(this, new EventArgs());
        }

        public static implicit operator bool(Pin pin)
        {
            return pin.State;
        }
    }
}
