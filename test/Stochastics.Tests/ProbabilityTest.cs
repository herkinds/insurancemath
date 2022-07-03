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

        [Fact]
        public void Complement_One_Zero()
        {
            var actual = Probability.One.Complement();
            var expected = Probability.Zero;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.5, 0.5)]
        [InlineData(0.75, 0.25)]
        [InlineData(0.25, 0.75)]
        [InlineData(0.1, 0.9)]
        [InlineData(0.0001, 0.9999)]
        public void Complement_Values_(decimal probability, decimal expected)
        {
            var actual = Probability.Parse(probability).Complement();
            Assert.Equal(expected, actual);
        }
    }
}