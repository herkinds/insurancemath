using System;

namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// The Bernoulli distribution defines success (i.e. 'true') of failure ('false') by a probability. This
    /// distribution is like a coin flip for heads (or tails).
    /// </summary>
    public class BernoulliDistribution : IProbabilityDistribution<bool>
    {
        private readonly IRandomNumberGenerator<Probability> generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BernoulliDistribution"/> class.
        /// </summary>
        /// <param name="generator">The random number generator.</param>
        /// <param name="successProbability">The probability for success, i.e. 'true'.</param>
        /// <exception cref="ArgumentNullException">If <see cref="generator"/> is null.</exception>
        public BernoulliDistribution(IRandomNumberGenerator<Probability> generator, Probability successProbability)
        {
            this.generator = generator ?? throw new ArgumentNullException(nameof(generator));
            this.SuccessProbability = successProbability;
        }

        /// <summary>
        /// Gets the probability for success, meaning the result 'true'."/>.
        /// </summary>
        public Probability SuccessProbability { get; }

        /// <inheritdoc/>
        public Probability CumulativeDistributionFunction(bool boundary)
        {
            if (boundary)
            {
                return Probability.One;
            }

            return this.SuccessProbability.Complement();
        }

        /// <inheritdoc/>
        public bool Draw()
        {
            return this.generator.Generate() <= this.SuccessProbability;
        }
    }
}
