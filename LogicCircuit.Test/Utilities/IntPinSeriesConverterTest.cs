using FluentAssertions;
using LogicCircuit.Abstractions.Infrastructure;
using LogicCircuit.Infrastructure;
using LogicCircuit.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LogicCircuit.Test.Utilities
{
    [TestClass]
    public class IntPinSeriesConverterTest
    {
        [TestMethod, TestCategory("Utilities.Conversion")]
        public void IntConvertsToPinSeriesCorrectly()
        {
            //Given
            const int intValue = 0b00110110;
            var pinSeries = new PinSeries(GetPin(), GetPin(), GetPin(), GetPin(), GetPin(), GetPin(), GetPin(), GetPin());

            //When
            pinSeries.Set(intValue);

            //Then
            pinSeries[0].Should().BeFalse();
            pinSeries[1].Should().BeTrue();
            pinSeries[2].Should().BeTrue();
            pinSeries[3].Should().BeFalse();
            pinSeries[4].Should().BeTrue();
            pinSeries[5].Should().BeTrue();
            pinSeries[6].Should().BeFalse();
            pinSeries[7].Should().BeFalse();
        }

        [TestMethod, TestCategory("Utilities.Conversion")]
        public void PinSeriesConvertsToIntCorrectly()
        {
            //Given
            const int expectedValue = 0b00110110;
            var pinSeries = new PinSeries(
                GetPin(false), GetPin(false), GetPin(true), GetPin(true), 
                GetPin(false), GetPin(true), GetPin(true), GetPin(false)
            );

            //When
            var actualValue = pinSeries.Read();

            //Then
            actualValue.Should().Be(expectedValue);
        }

        private IPin GetPin(bool state = false)
        {
            var pinMock = new Mock<IPin>();
            pinMock.SetupProperty(p => p.State);
            var pin = pinMock.Object;
            pin.State = state;
            return pin;
        }
    }
}
