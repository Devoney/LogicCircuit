using LogicCircuit.Infrastructure;

namespace LogicCircuit.Alu.Compare
{
    public class Comparer8Bit
    {
        private readonly ChainableComparer Comparer1 = new ChainableComparer();
        private readonly ChainableComparer Comparer2 = new ChainableComparer();
        private readonly ChainableComparer Comparer3 = new ChainableComparer();
        private readonly ChainableComparer Comparer4 = new ChainableComparer();
        private readonly ChainableComparer Comparer5 = new ChainableComparer();
        private readonly ChainableComparer Comparer6 = new ChainableComparer();
        private readonly ChainableComparer Comparer7 = new ChainableComparer();
        private readonly ChainableComparer Comparer8 = new ChainableComparer();

        public InputPinSeries InputA { get; private set; }
        public InputPinSeries InputB { get; private set; }

        public OutputPin IsLessThan {  get { return Comparer1.IsLessThanOutput; } }
        public OutputPin IsEqualTo {  get { return Comparer1.IsEqualToOutput; } }
        public OutputPin IsGreaterThan { get { return Comparer1.IsGreaterThanOutput; } }

        public Comparer8Bit()
        {
            InputA = new InputPinSeries(Comparer1.InputA, Comparer2.InputA, Comparer3.InputA, Comparer4.InputA,
                                        Comparer5.InputA, Comparer6.InputA, Comparer7.InputA, Comparer8.InputA);

            InputB = new InputPinSeries(Comparer1.InputB, Comparer2.InputB, Comparer3.InputB, Comparer4.InputB,
                                        Comparer5.InputB, Comparer6.InputB, Comparer7.InputB, Comparer8.InputB);

            Comparer8.IsOn.State = true;
            
            ChainComparer(Comparer8, Comparer7);
            ChainComparer(Comparer7, Comparer6);
            ChainComparer(Comparer6, Comparer5);
            ChainComparer(Comparer5, Comparer4);
            ChainComparer(Comparer4, Comparer3);
            ChainComparer(Comparer3, Comparer2);
            ChainComparer(Comparer2, Comparer1);
        }

        //Little bit cheating here. I did not want to write all code for chaining the comparers fully... You get the point...
        //TODO: Remove this method and replace it effectively.
        private void ChainComparer(ChainableComparer mostSignificantComparer, ChainableComparer leastSignificantComparer)
        {
            leastSignificantComparer.IsLessThanInput.ConnectTo(mostSignificantComparer.IsLessThanOutput);
            leastSignificantComparer.IsGreaterThanInput.ConnectTo(mostSignificantComparer.IsGreaterThanOutput);
            leastSignificantComparer.IsOn.ConnectTo(mostSignificantComparer.IsEqualToOutput);
        }
    }
}
