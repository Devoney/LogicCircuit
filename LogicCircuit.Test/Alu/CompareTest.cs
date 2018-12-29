using FluentAssertions;
using LogicCircuit.Alu.Compare;
using LogicCircuit.Infrastructure;
using LogicCircuit.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                lessThan.InputB.State = t.Item2;

                //Then
                lessThan.Output.State.Should().Be(t.Item3);
            }
        }

        [TestMethod]
        public void GreaterThanComparesCorrectly()
        {
            //Given
            var greaterThan = new GreaterThan();
            var table = new List<bool3>
            {
                new bool3(false, false, false),
                new bool3(false, true, false),
                new bool3(true, false, true),
                new bool3(true, true, false),
            };

            foreach (var t in table)
            {
                //When
                greaterThan.InputA.State = t.Item1;
                greaterThan.InputB.State = t.Item2;

                //Then
                greaterThan.Output.State.Should().Be(t.Item3);
            }
        }

        [TestMethod]
        public void ComparerComparesCorrectly()
        {
            //Given
            var truthTable = new List<CompareInputOutput>
            {
                new CompareInputOutput(false, false, isEqualTo: true),
                new CompareInputOutput(false, true, isLessThan: true),
                new CompareInputOutput(true, false, isGreaterThan: true),
                new CompareInputOutput(true, true, isEqualTo: true),
            };
            var comparer = new Comparer();

            foreach (var t in truthTable)
            {
                Trace.WriteLine(t);

                //When
                comparer.InputA.State = t.InputA;
                comparer.InputB.State = t.InputB;

                //Then
                comparer.IsLessThan.State.Should().Be(t.IsLessThan);
                comparer.IsEqualTo.State.Should().Be(t.IsEqualTo);
                comparer.IsGreaterThan.State.Should().Be(t.IsGreaterThan);
            }
        }

        [TestMethod]
        public void ChainableComparerPassesThroughInputCorrectyWhenSetToOff()
        {
            //Given
            var chainableComparer = new ChainableComparer();
            chainableComparer.IsOn.State = false;

            var truthTable = new List<CompareInputOutput>
            {
                new CompareInputOutput(false, false, isLessThan: true),
                new CompareInputOutput(false, true),
                new CompareInputOutput(true, false, isLessThan: true),
                new CompareInputOutput(true, true, isGreaterThan: true)
            };

            foreach (var t in truthTable)
            {
                //When
                chainableComparer.InputA.State = t.InputA;
                chainableComparer.InputB.State = t.InputB;
                chainableComparer.IsLessThanInput.State = t.IsLessThan;
                chainableComparer.IsGreaterThanInput.State = t.IsGreaterThan;

                //Then
                chainableComparer.IsLessThanOutput.State.Should().Be(t.IsLessThan);
                chainableComparer.IsEqualToOutput.State.Should().Be(t.IsEqualTo);
                chainableComparer.IsGreaterThanOutput.State.Should().Be(t.IsGreaterThan);
            }
        }

        [TestMethod]
        public void ChainableComparerComparesCorrectlyWhenSetToOn()
        {
            //Given
            var truthTable = new List<CompareInputOutput>
            {
                new CompareInputOutput(false, false, isEqualTo: true),
                new CompareInputOutput(false, true, isLessThan: true),
                new CompareInputOutput(true, false, isGreaterThan: true),
                new CompareInputOutput(true, true, isEqualTo: true),
            };
            var chainableComparer = new ChainableComparer();
            chainableComparer.IsOn.State = true;

            foreach (var t in truthTable)
            {
                Trace.WriteLine(t);

                //When
                chainableComparer.InputA.State = t.InputA;
                chainableComparer.InputB.State = t.InputB;

                //Then
                chainableComparer.IsLessThanOutput.State.Should().Be(t.IsLessThan);
                chainableComparer.IsEqualToOutput.State.Should().Be(t.IsEqualTo);
                chainableComparer.IsGreaterThanOutput.State.Should().Be(t.IsGreaterThan);
            }
        }

        [TestMethod]
        public void EightBitComparerComparesCorrectly()
        {
            //Given
            var comparer = new Comparer8Bit();
            var table = new List<Tuple<int, int, CompareOutput>>
            {
                new Tuple<int, int, CompareOutput>(45, 78, new CompareOutput(isLessThan: true)),
                new Tuple<int, int, CompareOutput>(0, 0, new CompareOutput(isEqualTo: true)),
                new Tuple<int, int, CompareOutput>(55, 55, new CompareOutput(isEqualTo: true)),
                new Tuple<int, int, CompareOutput>(255, 255, new CompareOutput(isEqualTo: true)),
                new Tuple<int, int, CompareOutput>(98, 12, new CompareOutput(isGreaterThan: true))
            };

            foreach(var t in table)
            {
                //When
                comparer.InputA.Set(t.Item1);
                comparer.InputB.Set(t.Item2);

                //Then
                comparer.IsLessThan.State.Should().Be(t.Item3.IsLessThan);
                comparer.IsEqualTo.State.Should().Be(t.Item3.IsEqualTo);
                comparer.IsGreaterThan.State.Should().Be(t.Item3.IsGreaterThan);
            }
        }

        private class CompareInputOutput : CompareOutput
        {
            public bool InputA { get; set; }
            public bool InputB { get; set; }

            public CompareInputOutput(bool inputA, bool inputB, bool isLessThan = false, bool isGreaterThan = false, bool isEqualTo = false)
                :base(isLessThan, isGreaterThan, isEqualTo)
            {
                InputA = inputA;
                InputB = inputB;
            }

            public override string ToString()
            {
                return $"{nameof(InputA)}: {InputA}, {nameof(InputB)}: {InputB}, " +
                    base.ToString(); 
            }
        }

        private class CompareOutput
        {
            public bool IsLessThan { get; set; }
            public bool IsGreaterThan { get; set; }
            public bool IsEqualTo { get; set; }

            public CompareOutput(bool isLessThan = false, bool isGreaterThan = false, bool isEqualTo = false)
            {
                IsLessThan = isLessThan;
                IsGreaterThan = isGreaterThan;
                IsEqualTo = isEqualTo;
            }

            public override string ToString()
            {
                return $"{nameof(IsLessThan)}: {IsLessThan}, {nameof(IsEqualTo)}: {IsEqualTo}, {nameof(IsGreaterThan)}: {IsGreaterThan}";
            }
        }
    }
}
