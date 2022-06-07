namespace Herkinds.InsuranceMath.Stochastics
{
    /// <summary>
    /// A static class with extension methods for <see cref="int"/>.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Computes the factorial for a number.
        /// </summary>
        /// <param name="number">The number to compute the factorial for.</param>
        /// <returns>The factorial value of the input number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the number is negative.</exception>
        public static long Factorial(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (number == 0)
            {
                return 1;
            }

            var factorial = (long)number;

            for (int i = 2; i < number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
