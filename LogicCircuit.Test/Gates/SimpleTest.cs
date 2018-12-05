using FluentAssertions;
using LogicCircuit.Gates.Simple;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Test.Gates
{
    [TestClass]
    public class SimpleTest
    {
        [TestMethod, TestCategory("Gate.Simple")]
        public void AND()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<AND>();

            //When + Then
            tester.Test(false, false, false, true);
        }

        [TestMethod, TestCategory("Gate.Simple")]
        public void NOT()
        {
            //Given
            var table = new Dictionary<bool, bool>
            {
                {false, true },
                {true, false }
            };
            var not = new NOT();

            //When
            foreach(var kvp in table)
            {
                var input = kvp.Key;
                var output = kvp.Value;

                not.InputA.State = input;
                not.Output.State.Should().Be(output);
            }
        }

        [TestMethod, TestCategory("Gate.Simple")]
        public void OR()
        {
            //Given
            var tester = new Input2Output1TruthTableTester<OR>();

            //When + Then
            tester.Test(false, true, true, true);
        }
    }
}
