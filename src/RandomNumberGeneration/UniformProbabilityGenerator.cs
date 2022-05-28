using Herkinds.InsuranceMath.Stochastics;

namespace Herkinds.InsuranceMath.RandomNumberGeneration
{
    /// <summary>
    /// A simple uniform probability distribution based on the implementationr of <see cref="Random.NextDouble"/>.
    /// </summary>
    public class UniformProbabilityGenerator : IRandomNumberGenerator<Probability>
    {
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniformProbabilityGenerator"/> class with a default seed of 0.
        /// </summary>
        public UniformProbabilityGenerator()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniformProbabilityGenerator"/> class.
        /// </summary>
        /// <param name="seed">The seed for the pseudorandom number generator.</param>
        public UniformProbabilityGenerator(int seed)
        {
            this.Seed = seed;
            this.random = new Random(seed);
        }

        /// <summary>
        /// Gets the seed of the random number generator.
        /// </summary>
        public int Seed { get; }

        /// <inheritdoc/>
        public Probability Generate()
        {
            var p = this.random.NextDouble();
            return Probability.Parse(p);
        }
    }
}
