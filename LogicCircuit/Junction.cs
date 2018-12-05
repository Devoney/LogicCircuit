using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicCircuit
{
    public class Junction
    {
        private List<Pin> pins = new List<Pin>();

        public IReadOnlyList<Pin> Pins
        {
            get
            {
                return pins;
            }
        }

        public void Add(Pin pin)
        {
            if (pins.Contains(pin)) return;
            pin.StateChanged += Pin_StateChanged;
            pins.Add(pin);
            ChangeJunctionStateByPin(pin);
        }

        private void Pin_StateChanged(object sender, EventArgs e)
        {
            var pin = sender as Pin;
            ChangeJunctionStateByPin(pin);
        }

        private void ChangeJunctionStateByPin(Pin pin)
        {
            var allHigh = pins.Any(p => p.IsOutput && p.State);
            if (allHigh) pin.State = true;
            foreach (var p in pins)
            {
                if (p == pin) continue;
                p.State = allHigh || pin.State;
            }
        }
    }
}
