namespace LogicCircuit.Gates.Simple
{
    public class OR : Abstractions.Gates.Simple.Gate2Input
    {
        public OR()
            :this(null)
        {

        }

        public OR(string name)
            : base(name)
        {

        }

        protected override bool Operation()
        {
            return InputA.State || InputB.State;
        }
    }
}
