namespace Herkinds.InsuranceMath.Stochastics.RandomNumberGenerator
{
    /// <summary>
    /// A pseudo-random number generator interface.
    /// </summary>
    /// <typeparam name="TNumber">The type of number that can be generated.</typeparam>
    public interface IRandomNumberGenerator<out TNumber>
        where TNumber : struct
    {
        /// <summary>
        /// Generates a pseudo-random number from the domain.
        /// </summary>
        /// <returns>A pseudo-random number.</returns>
        TNumber Generate();
    }
}
