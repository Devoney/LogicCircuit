using FluentAssertions;
using LogicCircuit.Alu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using bool4 = System.Tuple<bool, bool, bool, bool>;
using bool5 = System.Tuple<bool, bool, bool, bool, bool>;

namespace LogicCircuit.Test
{
    [TestClass]
    public class AluTest
    {
        [TestMethod, TestCategory("ALU")]
        public void HalfAdderSumsCorrectly()
        {
            //Given
            var halfAdder = new HalfAdder();
            var table = new List<bool4>
            {
                new bool4(false, false, false, false),
                new bool4(false, true, true, false),
                new bool4(true, false, true, false),
                new bool4(true, true, false, true),
            };
            
            foreach(var t in table)
            {
                //When
                halfAdder.InputA.State = t.Item1;
                halfAdder.InputB.State = t.Item2;

                //Then
                halfAdder.Sum.State.Should().Be(t.Item3);
                halfAdder.CarryOver.State.Should().Be(t.Item4);
            }
        }

        [TestMethod, TestCategory("ALU")]
        public void FullAdderSumsCorrectly()
        {
            //Given
            var fullAdder = new FullAdder();
            var table = new List<bool5>
            {
                //        InA,   Inb    Cin    Sum,    Cout
                new bool5(false, false, false, false, false),
                new bool5(false, false, true, true, false),
                new bool5(false, true, false, true, false),
                new bool5(false, true, true, false, true),
                new bool5(true, false, false, true, false),
                new bool5(true, false, true, false, true),
                new bool5(true, true, false, false, true),
                new bool5(true, true, true, true, true),
            };

            foreach (var t in table)
            {
                //When
                fullAdder.InputA.State = t.Item1;
                fullAdder.InputB.State = t.Item2;
                fullAdder.CarryIn.State = t.Item3;

                //Then
                fullAdder.Sum.State.Should().Be(t.Item4);
                fullAdder.CarryOver.State.Should().Be(t.Item5);
            }
        }
    }
}
