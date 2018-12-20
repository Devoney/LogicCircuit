using FluentAssertions;
using LogicCircuit.Alu;
using LogicCircuit.Alu.Subtract;
using LogicCircuit.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using bool4 = System.Tuple<bool, bool, bool, bool>;
using bool5 = System.Tuple<bool, bool, bool, bool, bool>;

namespace LogicCircuit.Test
{
    [TestClass]
    public class AluTest
    {
        [TestMethod, TestCategory("ALU.Subtracter")]
        public void HalfSubtracterSubtractsCorrectly()
        {
            //Given
            var halfSubtracter = new HalfSubtracter();

            var table = new List<bool4>
            {
                new bool4(false, false, false, false),
                new bool4(false, true, true, true),
                new bool4(true, false, true, false),
                new bool4(true, true, false, false),
            };

            foreach (var t in table)
            {
                //When
                halfSubtracter.InputA.State = t.Item1;
                halfSubtracter.InputB.State = t.Item2;

                //Then
                halfSubtracter.Sub.State.Should().Be(t.Item3);
                halfSubtracter.CarryOver.State.Should().Be(t.Item4);
            }
        }

        [TestMethod, TestCategory("ALU.Adder")]
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

        [TestMethod, TestCategory("ALU.Adder")]
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

        [TestMethod, TestCategory("ALU.Adder")]
        public void EightBitAdderSumsCorrectly()
        {
            //Given
            const int inputA = 23;
            const int inputB = 56;
            const int expectedSum = inputA + inputB;

            var adder = new Adder8Bit();

            //When
            adder.InputA.Set(inputA);
            adder.InputB.Set(inputB);

            //Then
            var actualSum = adder.Sum.Read();
            actualSum.Should().Be(expectedSum);
            adder.Overflow.State.Should().BeFalse();
        }

        [TestMethod, TestCategory("ALU.Adder")]
        public void EightBitAdderSetsOverflowHigh()
        {
            //Given
            const int inputA = 128;
            const int inputB = 128;

            var adder = new Adder8Bit();

            //When
            adder.InputA.Set(inputA);
            adder.InputB.Set(inputB);

            //Then
            adder.Overflow.State.Should().BeTrue();
        }

        [TestMethod, TestCategory("ALU.Adder")]
        public void DynamicAdderSumsCorrectly()
        {
            //Given
            const int inputA = 23;
            const int inputB = 56;
            const int expectedSum = inputA + inputB;

            var adder = new DynamicAdder(8);

            //When
            adder.InputA.Set(inputA);
            adder.InputB.Set(inputB);

            //Then
            var actualSum = adder.Sum.Read();
            actualSum.Should().Be(expectedSum);
            adder.Overflow.State.Should().BeFalse();
        }

        [TestMethod, TestCategory("ALU.Adder")]
        public void DynamicAdderSetsOverflowHigh()
        {
            //Given
            const int inputA = 128;
            const int inputB = 128;

            var adder = new DynamicAdder(8);

            //When
            adder.InputA.Set(inputA);
            adder.InputB.Set(inputB);

            //Then
            adder.Overflow.State.Should().BeTrue();
        }
    }
}
