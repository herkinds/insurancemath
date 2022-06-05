
namespace Stochastics.Tests
{
    public class ProbabilityTest
    {
        [Fact]
        public void Complement_Zero_One()
        {
            var actual = Probability.Zero.Complement();
            var expected = Probability.One;

            Assert.Equal(expected, actual);
        }
    }
}