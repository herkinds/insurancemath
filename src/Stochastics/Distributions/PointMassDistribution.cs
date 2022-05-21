namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// A point mass probability distribution, where all probability mass is on a single point.
    /// </summary>
    public class PointMassDistribution : IDistribution<decimal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointMassDistribution"/> class.
        /// </summary>
        /// <param name="point">The point on which all probability mass lies.</param>
        public PointMassDistribution(decimal point)
        {
            this.Point = point;
        }

        /// <summary>
        /// Gets the point on which all probability mass lies.
        /// </summary>
        public decimal Point { get; }

        /// <inheritdoc/>
        public Probability CumulativeDistributionFunction(decimal boundary)
        {
            if (this.Point <= boundary)
            {
                return Probability.One;
            }

            return Probability.Zero;
        }
    }
}
