using Herkinds.InsuranceMath.Stochastics.Parameters;

namespace Herkinds.InsuranceMath.Stochastics.Distributions
{
    /// <summary>
    /// The Pareto distribution is a power-law probability distribution with a heavy tail.
    /// </summary>
    public class ParetoDistribution : IProbabilityDistribution<double>
    {
        private readonly IRandomNumberGenerator<Probability> generator;
        private readonly ParetoParameters parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParetoDistribution"/> class.
        /// </summary>
        /// <param name="generator">The random number generator.</param>
        /// <param name="parameters">The Pareto distribution parameters.</param>
        /// <exception cref="ArgumentNullException">If parameters is null.</exception>
        public ParetoDistribution(IRandomNumberGenerator<Probability> generator, ParetoParameters parameters)
        {
            this.generator = generator ?? throw new ArgumentNullException(nameof(generator));
            this.parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        /// <inheritdoc/>
        public Probability CumulativeDistributionFunction(double boundary)
        {
            if (boundary < this.parameters.Scale)
            {
                return Probability.Zero;
            }

            var probability = 1 - Math.Pow(this.parameters.Scale / boundary, this.parameters.Shape);

            return Probability.Parse(probability);
        }

        /// <inheritdoc/>
        public double Draw()
        {
            var probability = this.generator.Generate().ToDouble();

            return this.parameters.Scale / Math.Pow(1 - probability, 1 / this.parameters.Shape);
        }
    }
}
