namespace LogicCircuit.Gates.Simple
{
    public class NOT : Abstractions.Gates.Simple.Gate1Input
    {
        public NOT(string name = null)
            : base(name)
        {
            Output.State = !InputA.State;
        }

        protected override bool Operation()
        {
            return !InputA;
        }
    }
}
