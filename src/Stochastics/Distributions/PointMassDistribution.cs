using System;

namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// A point mass probability distribution, where all probability mass is on a single point. Some might
    /// also know this distribution as the Dirac delta function.
    /// </summary>
    /// <typeparam name="TDomain">The domain on which the probability distribution is defined.</typeparam>
    public class PointMassDistribution<TDomain> : IProbabilityDistribution<TDomain>
        where TDomain : IComparable<TDomain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointMassDistribution{TDomain}"/> class.
        /// </summary>
        /// <param name="point">The point on which all probability mass lies.</param>
        public PointMassDistribution(TDomain point)
        {
            this.Point = point;
        }

        /// <summary>
        /// Gets the point on which all probability mass lies.
        /// </summary>
        public TDomain Point { get; }

        /// <inheritdoc/>
        public Probability CumulativeDistributionFunction(TDomain boundary)
        {
            if (this.Point.CompareTo(boundary) <= 0)
            {
                return Probability.One;
            }

            return Probability.Zero;
        }

        /// <inheritdoc/>
        public TDomain Draw()
            => this.Point;
    }
}
