using FluentAssertions;
using JSC.DroneAssembler.Shared;
using Xunit;

namespace JSC.DroneAssembler.Test
{
    public class SharedTest
    {
        [Fact]
        public void GetMaximumPeaksPossible_ReturnsCorrectValue()
        {
            var heights = new List<uint> { 1, 2, 3, 4, 5, 6, 7 };

            var result = heights.GetMaximumPeaksPossible();

            result.Should().Be(3);
        }
        [Fact]
        public void GetMaximumPeaksPossible_when_no_peaks_returnsCorrectValue()
        {
            var heights = new List<uint> { 1, 1, 1, 1, 1, 1, 1 };

            var result = heights.GetMaximumPeaksPossible();

            result.Should().Be(3);
        }
        [Fact]
        public void GetLastPeakIndex_ReturnsCorrectValue()
        {
            var heights = new List<uint> { 1, 2, 3, 2, 1 };

            var result = heights.GetLastPeakIndex();

            result.Should().Be(2);
        }

        [Fact]
        public void GetLastPeakIndex_when_no_peaks_returnsCorrectValue()
        {
            var heights = new List<uint> { 1, 1, 1, 1, 1 };

            var result = heights.GetFirstPeakIndex();

            result.Should().Be(0);
        }

        [Fact]
        public void GetFirstPeakIndex_returnsCorrectValue()
        {
            var heights = new List<uint> { 1, 2, 3, 2, 1 };

            var result = heights.GetFirstPeakIndex();

            result.Should().Be(2);
        }
        [Fact]
        public void GetFirstPeakIndex_when_no_peaks_returnsCorrectValue()
        {
            var heights = new List<uint> { 1, 1, 1, 1, 1 };

            var result = heights.GetFirstPeakIndex();

            result.Should().Be(0);
        }
    }
}
