using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicCircuit.Infrastructure
{
    public class Junction
    {
        private OutputPin outputPin;
        private List<InputPin> inputPins = new List<InputPin>();
        private List<Pin> pins = new List<Pin>();

        public void Add(InputPin pin)
        {
            if (inputPins.Contains(pin)) return;
            inputPins.Add(pin);
            AddInternal((Pin)pin);
            ChangeJunctionStateByPin(pin);
        }

        public void Add(OutputPin pin)
        {
            if (outputPin != null) throw new InvalidOperationException("Only one output pin is allowed per junction, and it has already been set.");
            outputPin = pin;
            AddInternal(pin);
            ChangeJunctionStateByPin(pin);
        }

        public void Add(Pin pin)
        {
            var inputPin = pin as InputPin;
            if (inputPin != null)
            {
                Add(inputPin);
                return;
            }

            var outputPin = pin as OutputPin;
            if (outputPin != null)
            {
                Add(outputPin);
                return;
            }

            throw new InvalidOperationException("Unknown pin type.");
        }

        private void AddInternal(Pin pin)
        {
            if (pins.Contains(pin)) return;
            pin.StateChanged += Pin_StateChanged;
            pins.Add(pin);
        }

        private void Pin_StateChanged(object sender, EventArgs e)
        {
            var inputPin = sender as InputPin;
            if (inputPin != null)
            {
                ChangeJunctionStateByPin(inputPin);
                return;
            }

            var outputPin = sender as OutputPin;
            if (outputPin != null)
            {
                ChangeJunctionStateByPin(outputPin);
                return;
            }

            throw new InvalidOperationException("Unknown pin type.");
        }

        private void ChangeJunctionStateByPin(InputPin pin)
        {
            var allHigh = AllHigh();
            if (allHigh) pin.State = true;
            foreach (var p in inputPins)
            {
                if (p == pin) continue;
                p.State = allHigh || pin.State;
            }
        }

        private void ChangeJunctionStateByPin(OutputPin pin)
        {
            foreach (var p in inputPins)
            {
                p.State = pin;
            }
        }

        private bool AllHigh()
        {
            return outputPin != null && outputPin.State;
        }
    }
}
