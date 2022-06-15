namespace Stochastics.Tests
{
    public class BinomialCoefficientsTest
    {
        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 0, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 0, 1)]
        [InlineData(3, 1, 3)]
        [InlineData(3, 2, 3)]
        [InlineData(3, 3, 1)]
        [InlineData(10, 6, 210)]
        [InlineData(13, 8, 1287)]
        [InlineData(20, 10, 184756)]

        public void NChooseK(int n, int k, int expected)
        {
            var bc = BinomialCoefficients.ComputeAndCreate(n);
            var actual = bc.Get(k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-47492)]

        public void ComputeAndCreate_NegativeN_ThrowsArgumentOutOfRangeException(int n)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                BinomialCoefficients.ComputeAndCreate(n);
            });
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(4, -6)]
        [InlineData(5, -1)]
        [InlineData(1, -3)]
        [InlineData(8, -7)]
        [InlineData(4, -1000)]
        public void Get_PositiveNAndNegativeK_ThrowsArgumentOutOfRangeException(int n, int k)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var bc = BinomialCoefficients.ComputeAndCreate(n);
                bc.Get(k);
            });
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        [InlineData(5, 7)]
        [InlineData(1, 3)]
        [InlineData(8, 10)]
        [InlineData(4, 1000)]
        public void Get_PositiveNAndGreaterK_ThrowsArgumentOutOfRangeException(int n, int k)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var bc = BinomialCoefficients.ComputeAndCreate(n);
                bc.Get(k);
            });
        }
    }
}
