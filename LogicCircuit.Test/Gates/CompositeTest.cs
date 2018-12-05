using LogicCircuit.Gates.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicCircuit.Test.Gates
{
    [TestClass]
    public class CompositeTests
    {
        [TestMethod, TestCategory("Gate.Composite")]
        public void NAND()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<NAND>();

            //When + Then
            tester.Test(true, true, true, false);
        }

        [TestMethod, TestCategory("Gate.Composite")]
        public void XOR()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<XOR>();

            //When + Then
            tester.Test(false, true, true, false);
        }

        [TestMethod, TestCategory("Gate.Composite")]
        public void NOR()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<NOR>();

            //When + Then
            tester.Test(true, false, false, false);
        }

        [TestMethod, TestCategory("Gate.Composite")]
        public void XNOR()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<XNOR>();

            //When + Then
            tester.Test(true, false, false, true);
        }
    }
}
