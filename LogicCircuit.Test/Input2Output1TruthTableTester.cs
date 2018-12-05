using FluentAssertions;
using LogicCircuit.Abstractions.Gates;

namespace LogicCircuit.Test
{
    public class Input2Output1TruthTableTester<TComponent>
        where TComponent : IInput2Output1, new()
    {
        private readonly TComponent component; 

        public Input2Output1TruthTableTester()
        {
            component = new TComponent();
        }

        public void Test(bool a, bool b, bool c, bool d)
        {
            var truthTable = new TruthTable2(a, b, c, d);

            foreach (var truthSet in truthTable)
            {
                //When
                component.InputA.State = truthSet.A;
                component.InputB.State = truthSet.B;
                var output = component.Output;

                //Then
                output.State.Should().Be(truthSet.C);
            }
        }
    }
}
