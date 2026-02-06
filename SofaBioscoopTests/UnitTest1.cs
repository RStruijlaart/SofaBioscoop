using FluentAssertions;

namespace SofaBioscoopTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int result = 1;
            result.Should().Be(2);
        }
    }
}