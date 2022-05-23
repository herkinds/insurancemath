using System;

namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// A probability distribution.
    /// </summary>
    /// <typeparam name="TDomain">The type of the domain on which the probability distribution is defined.</typeparam>
    public interface IProbabilityDistribution<TDomain>
        where TDomain : IComparable<TDomain>
    {
        /// <summary>
        /// Computes the cumulative distribution function.
        /// </summary>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The probability.</returns>
        Probability CumulativeDistributionFunction(TDomain boundary);

        /// <summary>
        /// Draws an element from the probability distribution.
        /// </summary>
        /// <returns>An element drawn from the probability distribution.</returns>
        TDomain Draw();
    }
}
