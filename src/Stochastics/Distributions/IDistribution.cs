using System;

namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// A probability distribution.
    /// </summary>
    /// <typeparam name="TDomain">The type of the domain on which the probability distribution is defined.</typeparam>
    public interface IDistribution<in TDomain>
        where TDomain : IComparable<TDomain>
    {
        /// <summary>
        /// Computes the cumulative distribution function.
        /// </summary>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The probability.</returns>
        Probability CumulativeDistributionFunction(TDomain boundary);
    }
}
