namespace LogicCircuit.Gates.Simple
{
    public class NOT : Abstractions.Gates.Simple.Gate1Input
    {
        public NOT(string name = null)
            : base(true, name)
        {
            
        }

        protected override bool Operation()
        {
            return !InputA;
        }
    }
}
