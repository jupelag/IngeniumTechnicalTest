using FluentAssertions;
using JSC.CannonLoader;
using JSC.CannonLoader.BinarySearch;
using JSC.CannonLoader.Contracts;
using Moq;
using Xunit;

namespace JSC.DroneAssembler.Test
{
    public class CannonLoaderTest
    {
        [Fact]
        public void GetCannonCount_when_heights_is_null()
        {
            var cannonLoader = new CannonLoader.CannonLoader(Mock.Of<ICannonLoaderSearchStrategy>());
            FluentActions.Invoking(() => cannonLoader.GetCannonCount(null)).Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void GetCannonCount_when_heights_is_empty()
        {
            var cannonLoader = new CannonLoader.CannonLoader(Mock.Of<ICannonLoaderSearchStrategy>());
            cannonLoader.GetCannonCount(Array.Empty<uint>()).Should().Be(0);
        }
        [Fact]
        public void GetCannonCount_when_heights_count_is_one()
        {
            var heights = new uint[] { 1 };
            var cannonLoader = new CannonLoader.CannonLoader(Mock.Of<ICannonLoaderSearchStrategy>());
            cannonLoader.GetCannonCount(heights).Should().Be(0);
        }
        [Fact]
        public void GetCannonCount_when_heights_is_a_plateau()
        {
            var heights = new uint[] { 1, 1, 1, 1, 1, 1, 1 };
            var cannonLoader = new CannonLoader.CannonLoader(Mock.Of<ICannonLoaderSearchStrategy>());
            var cannons = cannonLoader.GetCannonCount(heights).Should().Be(0);
        }
    }
}
