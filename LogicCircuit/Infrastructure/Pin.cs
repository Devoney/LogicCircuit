using LogicCircuit.Abstractions.Gates.Simple;
using LogicCircuit.Abstractions.Infrastructure;
using System;

namespace LogicCircuit.Infrastructure
{
    public class OutputPin : Pin, IOutputPin
    {
        private readonly Func<bool> setPinOperation;

        public bool State
        {
            get
            {
                return state;
            }
            private set
            {
                if (state != value)
                {
                    state = value;
                    OnStateChanged();
                }
            }
        }

        public OutputPin(Gate gate, Func<bool> setPinOperation, string name = null)
            :base(gate, name)
        {
            this.setPinOperation = setPinOperation;
        }

        public void SetState()
        {
            State = setPinOperation();
        }
    }

    public class InputPin : Pin, IInputPin
    {
        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnStateChanged();
                }
            }
        }

        public InputPin(Gate gate, string name = null)
            :base(gate, name)
        {

        }
    }

    public abstract class Pin
    {
        public event EventHandler StateChanged;
        public event EventHandler Connected;

        protected bool state;
        
        private Junction _junction;

        public Gate Gate
        {
            get; private set;
        }

        public string Name { get; set; }

        public Pin(Gate gate, string name = null)
        {
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

        protected void OnStateChanged()
        {
            if (!string.IsNullOrEmpty(Gate.Name) && !string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Gate: " + Gate.Name + " - PIN: " + Name + " = " + state);
            }
            if (StateChanged == null) return;
            StateChanged(this, new EventArgs());
        }

        public static implicit operator bool(Pin pin)
        {
            return pin.state;
        }
    }
}
