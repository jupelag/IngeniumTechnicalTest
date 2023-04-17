using FluentAssertions;
using Xunit;

namespace JSC.DroneAssembler.Test
{
    public class CannonLoaderTest
    {
        [Fact]
        public void GetCannonCount_returns_correct_number()
        {
            var heights = new uint[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            var cannonLoader = new CannonLoader();
            var cannons = cannonLoader.GetCannonCount(heights).Should().Be(3);
        }
    }
}
