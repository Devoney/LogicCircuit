using FluentAssertions;
using LogicCircuit.Alu.Compare;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using bool3 = System.Tuple<bool, bool, bool>;

namespace LogicCircuit.Test.Alu
{
    [TestClass]
    public class CompareTest
    {
        [TestMethod]
        public void LessThanComparesCorrectly()
        {
            //Given
            var lessThan = new LessThan();
            var table = new List<bool3>
            {
                new bool3(false, false, false),
                new bool3(false, true, true),
                new bool3(true, false, false),
                new bool3(true, true, false),
            };

            foreach (var t in table)
            {
                //When
                lessThan.InputA.State = t.Item1;
                lessThan.inputB.State = t.Item2;

                //Then
                lessThan.Output.State.Should().Be(t.Item3);
            }
        }
    }
}
