namespace Herkinds.InsuranceMath.Stochastics
{
    /// <summary>
    /// A class to compute the binomaial coefficients through dynamic programming.
    /// </summary>
    public sealed class BinomialCoefficients
    {
        private readonly int n;
        private readonly int[][] coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinomialCoefficients"/> class.
        /// </summary>
        /// <param name="n">The maximum number n.</param>
        /// <param name="coefficients">The binomial coefficients.</param>
        private BinomialCoefficients(int n, int[][] coefficients)
        {
            this.n = n;
            this.coefficients = coefficients ?? throw new ArgumentNullException(nameof(coefficients));
        }

        /// <summary>
        /// Computes and creates the binomial coefficients for a number to choose from.
        /// </summary>
        /// <param name="n">The maximum number to choose from.</param>
        /// <returns>The binomial coefficients.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If n is smaller than 0.</exception>
        public static BinomialCoefficients ComputeAndCreate(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            int i, j;

            var coefficients = new int[n + 1][];

            for (i = 0; i <= n; i++)
            {
                coefficients[i] = new int[i + 1];
                for (j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        coefficients[i][j] = 1;
                    }
                    else
                    {
                        coefficients[i][j] = coefficients[i - 1][j - 1] + coefficients[i - 1][j];
                    }
                }
            }

            return new BinomialCoefficients(n, coefficients);
        }

        /// <summary>
        /// Gets the binomial coefficient, n choose k.
        /// </summary>
        /// <param name="k">The number to choose.</param>
        /// <returns>The binomial coefficient.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If k is greater than n or k is smaller than 0.</exception>
        public int Get(int k)
        {
            if (k > this.n || k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k));
            }

            return this.coefficients[this.n][k];
        }

        /// <summary>
        /// Gets the binomial coefficient, n choose k.
        /// </summary>
        /// <param name="n">The number to choose from.</param>
        /// <param name="k">The number to choose.</param>
        /// <returns>The binomial coefficient.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If n is smaller than 0;
        /// if k is greater than n or k is smaller than 0.</exception>
        public int Get(int n, int k)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (k > n || k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k));
            }

            return this.coefficients[n][k];
        }
    }
}
