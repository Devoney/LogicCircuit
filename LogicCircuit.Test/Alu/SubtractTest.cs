using FluentAssertions;
using LogicCircuit.Alu.Subtract;
using LogicCircuit.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using bool4 = System.Tuple<bool, bool, bool, bool>;
using bool5 = System.Tuple<bool, bool, bool, bool, bool>;

namespace LogicCircuit.Test.Alu
{
    [TestClass]
    public class SubtractTest
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

        [TestMethod, TestCategory("ALU.Subtracter")]
        public void FullSubtracterSubsCorrectly()
        {
            //Given
            var fullAdder = new FullSubtracter();
            var table = new List<bool5>
            {
                //        Cin,   Ina    Inb    Sub,    Cout
                new bool5(false, false, false, false, false),
                new bool5(false, false, true, true, true),
                new bool5(false, true, false, true, false),
                new bool5(false, true, true, false, false),
                new bool5(true, false, false, true, true),
                new bool5(true, false, true, false, true),
                new bool5(true, true, false, false, false),
                new bool5(true, true, true, true, true),
            };

            foreach (var t in table)
            {
                //When
                fullAdder.CarryIn.State = t.Item1;
                fullAdder.InputA.State = t.Item2;
                fullAdder.InputB.State = t.Item3;

                //Then
                fullAdder.Sub.State.Should().Be(t.Item4);
                fullAdder.CarryOver.State.Should().Be(t.Item5);
            }
        }

        [TestMethod, TestCategory("ALU.Subtracter")]
        public void EightBitSubtracterSubsCorrectly()
        {
            //Given
            const int inputA = 56;
            const int inputB = 23;
            const int expectedSub = inputA - inputB;

            var subtracter = new Subtracter8Bit();

            //When
            subtracter.InputA.Set(inputA);
            subtracter.InputB.Set(inputB);

            //Then
            var actualSub = subtracter.Sub.Read();
            actualSub.Should().Be(expectedSub);
            subtracter.Overflow.State.Should().BeFalse();
        }
    }
}
