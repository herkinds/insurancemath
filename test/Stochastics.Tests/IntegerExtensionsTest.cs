namespace Stochastics.Tests
{
    public class IntegerExtensionsTest
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(10, 3628800)]
        [InlineData(15, 1307674368000)]
        public void Factorial_NonNegativeInput_CorrectOutput(int number, long expected)
        {
            var actual = number.Factorial();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_NegativeInput_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var number = -1;
                number.Factorial();
            });
        }
    }
}
