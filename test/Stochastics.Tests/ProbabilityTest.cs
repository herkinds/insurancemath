
namespace Stochastics.Tests
{
    public class ProbabilityTest
    {
        [Fact]
        public void Complement_Test()
        {
            var actual = Probability.Zero.Complement();
            var expected = Probability.One;

            Assert.Equal(expected, actual);
        }
    }
}